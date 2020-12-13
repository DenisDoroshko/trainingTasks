using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The class representing a circle
    /// </summary>
    
    public class Circle : Figure
    {
        /// <summary>
        /// Creates an instance of the Circle class
        /// </summary>
        /// <param name="sides">Sides of figure</param>
        
        public Circle(double[] sides) : base($"{FigureTypes.Circle}", sides)
        {
            if (sides.Length != 1)
                throw new IncorrectParametersException("Must be only radius");
        }

        /// <summary>
        /// Gets area of a figure
        /// </summary>
        /// <returns>The area of a figure</returns>
        
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Sides[0],2);
        }

        /// <summary>
        /// Gets perimeter of a figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>
        
        public override double GetPerimeter()
        {
            return 2*Math.PI*Sides[0];
        }
    }
}
