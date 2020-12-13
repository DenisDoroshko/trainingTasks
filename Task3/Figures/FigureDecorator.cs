using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The abstract class representing a figure wiht material
    /// </summary>

    public abstract class FigureDecorator:Figure
    {
        /// <summary>
        /// Initial figure
        /// </summary>
        
        public Figure figure;

        /// <summary>
        /// Cut of the figure
        /// </summary>
        
        public double CutOfFigure;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of a figure</param>
        /// <param name="sides">Sides of a figure</param>
        /// <param name="figure">Initial figure</param>
        
        public FigureDecorator(string name,double[] sides,Figure figure):base(name,sides)
        {
            this.figure = figure;
        }

        /// <summary>
        /// Class constructor that cuts a figure from another figure
        /// </summary>
        /// <param name="originalFigure">Original figure</param>
        /// <param name="newFigure">New initial figure</param>
        /// <param name="name">Name of a figure</param>
        /// <param name="sides">Sides of figure</param>
        
        public FigureDecorator(FigureDecorator originalFigure, Figure newFigure,string name,double[] sides) : base(name, sides)
        {
            if (originalFigure.Area < newFigure.Area || originalFigure.Perimeter < newFigure.Perimeter)
            {
                throw new CutFigureException();
            }
            else
            {
                this.figure = newFigure;
                originalFigure.CutOfFigure += newFigure.Area;
                this.color = originalFigure.Color;
            }
        }

        /// <summary>
        /// Gets the area of a figure
        /// </summary>
        /// <returns>The area of a figure</returns>
        
        public override double GetArea()
        {
            return figure.GetArea()-CutOfFigure;
        }

        /// <summary>
        /// Gets the perimeter of a figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>
        
        public override double GetPerimeter()
        {
            return figure.GetPerimeter();
        }

        /// <summary>
        /// Converts instance of class to string
        /// </summary>
        /// <returns>String representation of instance of class</returns>

        public override string ToString()
        {
            var stringSides = "";
            foreach(var side in Sides)
            {
                stringSides += $"{side} ";
            }
            return $"Name:{Name} Sides:{stringSides} Color:{Color}";
        }
    }
}
