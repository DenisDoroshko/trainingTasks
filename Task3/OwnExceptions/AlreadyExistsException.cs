using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents an already exists figure error
    /// </summary>

    public class AlreadyExistsException:Exception
    {
        /// <summary>
        /// Creates an already exists figure error
        /// </summary>

        public AlreadyExistsException() : base("The figure already exists in box.")
        {
        }

        /// <summary>
        /// Creates an already exists figure error
        /// </summary>

        public AlreadyExistsException(string message) : base(message)
        {
        }
    }
}
