using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The class representing a rectangle
    /// </summary>

    public class Rectangle:Figure
    {
        /// <summary>
        /// Creates an instance of the Rectangle class
        /// </summary>
        /// <param name="sides">Sides of figure</param>

        public Rectangle(double[] sides) : base($"{FigureTypes.Rectangle}", sides)
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
            return Sides[0]*Sides[2];
        }

        /// <summary>
        /// Gets perimeter of a figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>

        public override double GetPerimeter()
        {
            return Sides[0] + Sides[1] + Sides[2] + Sides[3];
        }
    }
}
