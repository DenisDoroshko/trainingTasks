using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    public class PlasticFigure:FigureDecorator
    {
        public PlasticFigure(Figure figure) : base($"{figure.Name} {MaterialTypes.Plastic}",figure.Sides,figure)
        {

        }
        public PlasticFigure(FigureDecorator originalFigure,Figure newFigure) : base(originalFigure, newFigure,$"{newFigure.Name} {MaterialTypes.Plastic}", newFigure.Sides)
        {
        }
        protected bool isChangedColor = false;
        public bool IsChangedColor { get { return isChangedColor; }}
        public override Colors Color 
        { 
            get 
            { 
                return color; 
            } 
            set 
            {
                color = value;
                isChangedColor = true;
            } 
        }
        public override string ToString()
        {
            var sidesString = "";
            foreach (var side in Sides)
            {
                sidesString += $"{side} ";
            }
            return $"Name:{Name} Sides:{sidesString} Color:{Color}";
        }
    }
}
