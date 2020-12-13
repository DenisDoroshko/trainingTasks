using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents a paint figure error
    /// </summary>

    public class PaintFigureException:Exception
    {
        /// <summary>
        /// Creates a incorrect parameters error
        /// </summary>

        public PaintFigureException() : base("The figure can't be painted.")
        {
        }

        /// <summary>
        /// Creates a incorrect parameters error
        /// </summary>

        public PaintFigureException(string message) : base(message)
        {
        }
    }
}
