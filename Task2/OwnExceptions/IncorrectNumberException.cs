using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents an incrorrect number error
    /// </summary>

    public class IncorrectNumberException:Exception
    {
        /// <summary>
        /// Creates an incrorrect number error
        /// </summary>

        public IncorrectNumberException() : base("Number of products is less then given number")
        {
        }

        /// <summary>
        /// Creates an incrorrect number error
        /// </summary>

        public IncorrectNumberException(string message) : base(message)
        {
        }
    }
}
