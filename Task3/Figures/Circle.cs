using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    public class Circle : Figure
    {
        public Circle(double[] sides) : base($"{FigureTypes.Circle}", sides)
        {
            if (sides.Length != 1)
                throw new IncorrectParametersException("Must be only radius");
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Sides[0],2);
        }
        public override double GetPerimeter()
        {
            return 2*Math.PI*Sides[0];
        }
        public override string ToString()
        {
            return $"{Name} {Sides[0]} {Color}";
        }
    }
}
