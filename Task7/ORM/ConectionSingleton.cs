using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace ORM
{
    /// <summary>
    /// Representts a class for creating a connection
    /// </summary>
    
    public sealed class ConectionSingleton
    {
        /// <summary>
        /// Instance of the class
        /// </summary>
        
        static ConectionSingleton instance;

        /// <summary>
        /// Sql connection
        /// </summary>
        
        private static DataContext connection;

        /// <summary>
        /// Creates an instance of the ConectionSingleton class
        /// </summary>
        
        private ConectionSingleton()
        {
        }

        /// <summary>
        /// Gets sql connection
        /// </summary>
        
        public static DataContext Connection
        {
            get { return connection; }
        }

        /// <summary>
        /// Gets an instance of ConectionSingleton class
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>An instance of ConectionSingleton class</returns>
        
        public static ConectionSingleton GetInstance(string connectionString)
        {
                if (instance == null)
                {
                    instance = new ConectionSingleton();
                    connection = new DataContext(connectionString);
                }
                return instance;
        }
    }
}
