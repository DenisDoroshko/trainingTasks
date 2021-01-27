using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    /// <summary>
    /// Represents session data
    /// </summary>
    
    public interface IData
    {
        /// <summary>
        /// Id of a data element
        /// </summary>
        
        Guid Id { get; set; }
    }
}
