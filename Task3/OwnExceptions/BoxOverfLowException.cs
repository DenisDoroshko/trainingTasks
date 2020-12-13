using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents a box overfLow error
    /// </summary>

    public class BoxOverfLowException:Exception
    {
        /// <summary>
        /// Creates a box overfLow error
        /// </summary>

        public BoxOverfLowException() : base("Box overflow.")
        {
        }

        /// <summary>
        /// Creates a box overfLow error
        /// </summary>

        public BoxOverfLowException(string message) : base(message)
        {
        }
    }
}
