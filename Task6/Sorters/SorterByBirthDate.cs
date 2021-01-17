using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Sorters
{
    /// <summary>
    /// Representts a class for a sorting students by birthdate
    /// </summary>
    
    public class SorterByBirthDate:ISorter
    {
        /// <summary>
        /// Sorts students by birthdate
        /// </summary>
        /// <param name="group">Selected group</param>
        
        public void Sort(Group group)
        {
            group.Students = group.Students.OrderBy(i => i.BirthDate).ToList();
        }
    }
}
