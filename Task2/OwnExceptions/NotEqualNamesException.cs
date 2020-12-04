using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents a not equal names error
    /// </summary>
    
    public class NotEqualNamesException:Exception
    {
        /// <summary>
        /// Creates a not equal names error
        /// </summary>

        public NotEqualNamesException() : base("Names are not equal")
        {
        }

        /// <summary>
        /// Creates a not equal names error
        /// </summary>

        public NotEqualNamesException(string message) : base(message)
        {
        }
    }
}
