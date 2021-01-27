using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Sorters
{
    /// <summary>
    /// Representts a class for a sorting students by name
    /// </summary>
    
    public class SorterByName:ISorter
    {
        /// <summary>
        /// Sorts students by name
        /// </summary>
        /// <param name="group">Selected group</param>

        public void Sort(Group group)
        {
            group.Students =group.Students.OrderBy(i => i.FullName).ToList();
        }
    }
}
