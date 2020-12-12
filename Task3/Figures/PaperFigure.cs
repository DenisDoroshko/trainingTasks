using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    public class PaperFigure:FigureDecorator
    {
        public PaperFigure(Figure figure) : base($"{figure.Name} {MaterialTypes.Plastic}", figure.Sides, figure)
        {
        }
        public PaperFigure(FigureDecorator originalFigure, Figure newFigure) : base(originalFigure, newFigure, $"{newFigure.Name} {MaterialTypes.Plastic}", newFigure.Sides)
        {
        }
        protected bool isChangedColor = false;
        public bool IsChangedColor { get { return isChangedColor; } }
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
                    throw new Exception();
                }
                else
                {
                    color = value;
                    isChangedColor = true;
                }
            }
        }
    }
}
