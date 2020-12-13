using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The class representing a square
    /// </summary>

    public class Square:Figure
    {
        /// <summary>
        /// Creates an instance of the Square class
        /// </summary>
        /// <param name="sides">Sides of figure</param>

        public Square(double[] sides) : base($"{FigureTypes.Square}", sides)
        {
            if (sides.Length != 4)
                throw new IncorrectParametersException("Must be four sides");
        }

        /// <summary>
        /// Gets area of a figure
        /// </summary>
        /// <returns>The area of a figure</returns>

        public override double GetArea()
        {
            return Math.Pow(Sides[0],2);
        }

        /// <summary>
        /// Gets perimeter of a figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>

        public override double GetPerimeter()
        {
            return Sides[0]*4;
        }
    }
}
