﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The class representing a triangle
    /// </summary>

    public class Triangle : Figure
    {
        /// <summary>
        /// Creates an instance of the Triangle class
        /// </summary>
        /// <param name="sides">Sides of figure</param>

        public Triangle(double[] sides) : base($"{FigureTypes.Triangle}",sides)
        {
            if (sides.Length != 3)
                throw new IncorrectParametersException("Must be three sides");
        }

        /// <summary>
        /// Gets area of a figure
        /// </summary>
        /// <returns>The area of a figure</returns>

        public override double GetArea()
        {
            var semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter*(semiPerimeter-Sides[0])* (semiPerimeter - Sides[1])*(semiPerimeter - Sides[2]));
        }

        /// <summary>
        /// Gets perimeter of a figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>

        public override double GetPerimeter()
        {
            return Sides[0] + Sides[1] + Sides[2];
        }
    }
}
