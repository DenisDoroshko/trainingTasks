using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Figures
{
    public abstract class FigureDecorator:Figure, IMaterial
    {
        public Figure figure;
        public double CutFromFigure;
        public FigureDecorator(string name,double[] sides,Figure figure):base(name,sides)
        {
            this.figure = figure;
        }
        public FigureDecorator(FigureDecorator originalFigure, Figure newFigure,string name,double[] sides) : base(name, sides)
        {
            if (originalFigure.Area < newFigure.Area || originalFigure.Perimeter < newFigure.Perimeter)
            {
                throw new CutFigureException();
            }
            else
            {
                this.figure = newFigure;
                originalFigure.CutFromFigure -= newFigure.Area;
                this.color = originalFigure.Color;
            }
        }
        public override double GetArea()
        {
            return figure.GetArea()-CutFromFigure;
        }
        public override double GetPerimeter()
        {
            return figure.GetPerimeter();
        }
        public List<Figure> ReadWithXmlReader()
        {
            return null;
        }
        public void WriteWithXmlReader()
        {

            
        }
    }
}
