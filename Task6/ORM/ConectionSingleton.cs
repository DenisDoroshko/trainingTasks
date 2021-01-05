using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ORM
{
    public sealed class ConectionSingleton
    {
        static ConectionSingleton instance;
        private static SqlConnection sqlConnection;
        private ConectionSingleton()
        {
        }
        public static SqlConnection SqlConnection
        {
            get { return sqlConnection; }
        }
        public static ConectionSingleton GetInstance(string connectionString)
        {
                if (instance == null)
                {
                    instance = new ConectionSingleton();
                    sqlConnection = new SqlConnection(connectionString);
                }
                return instance;
        }
    }
}
