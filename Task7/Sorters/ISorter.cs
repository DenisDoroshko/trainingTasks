using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Sorters
{
    /// <summary>
    /// The interface for sorting
    /// </summary>
    
    interface ISorter
    {
        /// <summary>
        /// Sorts data 
        /// </summary>
        /// <param name="group">Selected group</param>
        
        void Sort(Group group);
    }
}
