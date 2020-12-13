using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents a incorrect parameters error
    /// </summary>

    public class IncorrectParametersException:Exception
    {
        /// <summary>
        /// Creates a incorrect parameters error
        /// </summary>

        public IncorrectParametersException() : base("Incorrect parameters error.")
        {
        }

        /// <summary>
        /// Creates a incorrect parameters error
        /// </summary>

        public IncorrectParametersException(string message) : base(message)
        {
        }
    }
}
