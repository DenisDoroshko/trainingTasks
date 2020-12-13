using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures 
{
    /// <summary>
    /// The abstract class representing a figure
    /// </summary>
    
    public abstract class Figure
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of figure</param>
        /// <param name="sides">Sides of figure</param>
        
        public Figure(string name,double[] sides)
        {
            Name = name;
            this.sides = sides;
        }

        /// <summary>
        /// Name of figure
        /// </summary>
        
        public string Name { get; protected set; }

        /// <summary>
        /// Protected field of figure sides
        /// </summary>

        protected double[] sides;

        /// <summary>
        /// Figure sides
        /// </summary>
        
        public double[] Sides { get { return sides; }}

        /// <summary>
        /// Area of a figure
        /// </summary>
        
        public double Area { get {return GetArea(); } }

        /// <summary>
        /// Perimeter of a figure
        /// </summary>
        
        public double Perimeter { get { return GetPerimeter(); } }

        /// <summary>
        /// Protected field of figure color
        /// </summary>
        
        protected Colors color = Colors.None;

        /// <summary>
        /// Figure color
        /// </summary>
        
        public virtual Colors Color { get {return color; }set { color = value; } }

        /// <summary>
        /// Gets area of a figure
        /// </summary>
        /// <returns>Area of a figure</returns>
        
        public abstract double GetArea();

        /// <summary>
        /// Gets perimeter of a figure
        /// </summary>
        /// <returns>Perimeter of a figure</returns>
        
        public abstract double GetPerimeter();
    }
}
