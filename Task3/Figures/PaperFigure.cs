using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    /// <summary>
    /// The class representing a paper figure
    /// </summary>

    public class PaperFigure:FigureDecorator
    {
        /// <summary>
        /// Creates an instance of the PaperFigure class
        /// </summary>
        /// <param name="figure">Initial figure</param>

        public PaperFigure(Figure figure) : base($"{figure.Name} {MaterialTypes.Paper}", figure.Sides, figure)
        {
        }

        /// <summary>
        /// Class constructor that cuts a figure from another figure
        /// </summary>
        /// <param name="originalFigure">Original figure</param>
        /// <param name="newFigure">New initial figure</param>

        public PaperFigure(FigureDecorator originalFigure, Figure newFigure) : base(originalFigure, newFigure, $"{newFigure.Name} {MaterialTypes.Paper}", newFigure.Sides)
        {
        }

        /// <summary>
        /// Protected field of whether the color is changed 
        /// </summary>

        protected bool isChangedColor = false;

        /// <summary>
        /// Whether the color was changed
        /// </summary>
        
        public bool IsChangedColor { get { return isChangedColor; } }

        /// <summary>
        /// Color of a figure
        /// </summary>

        public override Colors Color
        {
            get
            {
                return color;
            }
            set
            {
                if (isChangedColor == true)
                {
                    throw new PaintFigureException("The plastic figure can only be painted once.");
                }
                else
                {
                    color = value;
                    isChangedColor = true;
                }
            }
        }

        /// <summary>
        /// Converts instance of class to string
        /// </summary>
        /// <returns>String representation of instance of class</returns>

        public override string ToString()
        {
            return $"Name:{Name} Sides:{Sides.DoubleArrayToString()} Color:{Color}";
        }

        /// <summary>
        /// Redefining the Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                var figure = (PaperFigure)obj;
                if (Sides.Length == figure.Sides.Length)
                {
                    for (var i = 0; i < Sides.Length; i++)
                    {
                        if (Sides[i] != figure.Sides[i])
                        {
                            return false;
                        }
                    }
                    return Name == figure.Name && Color == figure.Color;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Calculates the hash code of the current object
        /// </summary>
        /// <returns>Hash code of the current object</returns>

        public override int GetHashCode()
        {
            return (int)Sides[0] / 3;
        }
    }
}
