using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// The interface for CRUD operations
    /// </summary>
    
    public interface IDAO
    {
        /// <summary>
        /// Inserts element to the database
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Element</param>
        
        void Insert<T>(T element);

        /// <summary>
        /// Updates data about specified element
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Specified element</param>
        
        void Update<T>(T element);

        /// <summary>
        /// Deletes specified element from database table
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Specififed element</param>
        
        void Delete<T>(T element);

        /// <summary>
        /// Gets all elements in database table by type
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <returns>List of objects</returns>
        
        List<T> Get<T>();
    }
}
