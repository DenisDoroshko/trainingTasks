using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    public class Triangle : Figure
    {
        public Triangle(double[] sides) : base($"{FigureTypes.Triangle}",sides)
        {
            if (sides.Length != 3)
                throw new IncorrectParametersException("Must be three sides");
        }
        public override double GetArea()
        {
            var semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter*(semiPerimeter-Sides[0])* (semiPerimeter - Sides[1])*(semiPerimeter - Sides[2]));
        }
        public override double GetPerimeter()
        {
            return Sides[0] + Sides[1] + Sides[2];
        }
    }
}
