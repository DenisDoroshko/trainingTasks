using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{

    /// <summary>
    /// Representts a base class for a creating session data objects
    /// </summary>

    public abstract class BaseCreator
    {
        /// <summary>
        /// Creates a session data object
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Session data object</returns>

        public abstract IData Create(List<object> values);
    }
}
