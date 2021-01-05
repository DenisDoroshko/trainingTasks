using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using SessionDataFactory;

namespace ORM
{
    public class AccessDB : IDAO
    {
        protected SqlConnection connection;
        public AccessDB(string connectionString)
        {
            ConectionSingleton.GetInstance(connectionString);
            connection = ConectionSingleton.SqlConnection;
        }

        public void Insert<T>(T element)
        {
            Type typeInfo = typeof(T);
            var typeName = typeInfo.Name;
            var properties = GetProperties(typeInfo);
            var stringPropertyNames = "";
            var stringParameters = "";
            for (var i = 0; i < properties.Count; i++)
            {
                stringPropertyNames += $" {properties[i].Name}";
                stringParameters += $" @{properties[i].Name}";
                if (i != properties.Count - 1)
                {
                    stringPropertyNames += ',';
                    stringParameters += ',';
                }
            }
            string sqlExpression = $"INSERT INTO {typeName}s ({stringPropertyNames}) VALUES ({stringParameters})";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SetParameters(command, properties, element);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update<T>(T element)
        {
            Type typeInfo = typeof(T);
            var typeName = typeInfo.Name;
            var properties = GetProperties(typeInfo);
            var stringParameters = "";
            for(var i = 0; i < properties.Count; i++) 
            { 
                stringParameters += $" {properties[i].Name}=@{properties[i].Name}";
                if (i != properties.Count - 1)
                    stringParameters += ',';
            }
            var elementId = typeInfo.GetProperty("Id").GetValue(element);
            string sqlExpression = $"UPDATE {typeName}s SET {stringParameters} WHERE Id={elementId}";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SetParameters(command, properties, element);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete<T>(T element)
        {
            Type typeInfo = typeof(T);
            var typeName = typeInfo.Name;
            var elementId = typeInfo.GetProperty("Id").GetValue(element);
            string sqlExpression = $"DELETE  FROM {typeName}s WHERE Id={elementId}";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<T> Get<T>()
        {
            Type typeInfo = typeof(T);
            var typeName = typeInfo.Name;
            string sqlExpression = $"SELECT * FROM {typeName}s";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            var elements = new List<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var values = new List<object>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        values.Add(reader.GetValue(i));
                    }
                    var element = BaseCreator.CreateByName(typeName, values);
                    elements.Add((T)element);
                }
            }
            reader.Close();
            connection.Close();
            return elements;
        }
        private List<PropertyInfo> GetProperties(Type typeInfo)
        {
            var properties = new List<PropertyInfo>();
            foreach (var property in typeInfo.GetProperties())
            {
                if (property.Name != "Id")
                    properties.Add(property);
            }
            return properties;
        }
        private void SetParameters<T>(SqlCommand command,List<PropertyInfo> properties,T element)
        {
            foreach (var property in properties)
            {
                object value = property.GetValue(element);
                SqlParameter parameter = new SqlParameter($"@{property.Name}", value);
                command.Parameters.Add(parameter);
            }
        }
    }

}
