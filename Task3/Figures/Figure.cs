using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures 
{ 
    public enum Colors
    {
        None,
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Orange,
        Black
    }
    public enum FigureTypes
    {
        Circle,
        Triangle,
        Square,
        Rectangle
    }

    public abstract class Figure
    {
        public Figure(string name,double[] sides)
        {
            Name = name;
            Sides = sides;
        }
        public string Name { get; protected set; }
        public double[] Sides { get; set; }
        public double Area { get {return GetArea(); } }
        public double Perimeter { get { return GetPerimeter(); } }
        protected Colors color = Colors.None;
        public virtual Colors Color { get {return color; }set { color = value; } }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
