using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using SessionData;
using System.Data.Linq;

namespace ORM
{
    /// <summary>
    /// Representts a class for a working with database
    /// </summary>
    
    public class AccessDB : IDAO
    {
        /// <summary>
        /// Data context
        /// </summary>
        
        protected DataContext dataBase;

        /// <summary>
        /// Creates an instance for working with database
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        
        public AccessDB(string connectionString)
        {
            ConectionSingleton.GetInstance(connectionString);
            dataBase = ConectionSingleton.Connection;
        }

        /// <summary>
        /// Inserts element to the database
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Element</param>

        public void Insert<T>(T element) where T :class
        {
            dataBase.GetTable<T>().InsertOnSubmit(element);
        }

        /// <summary>
        /// Updates data
        /// </summary>

        public void Update()
        {
            dataBase.SubmitChanges();
        }

        /// <summary>
        /// Deletes specified element from database table
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Specififed element</param>
        

        public void Delete<T>(T element) where T : class
        {
            dataBase.GetTable<T>().DeleteOnSubmit(element);
        }

        /// <summary>
        /// Gets all elements in database table by type
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <returns>List of objects</returns>

        public List<T> Get<T>() where T : class
        {
            return dataBase.GetTable<T>().ToList();
        }
    }

}
