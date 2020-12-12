using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    public static class BoxOfFigures
    {
        static BoxOfFigures()
        {
            FiguresList = new List<Figure>(BoxSize);
        }
        public const int BoxSize = 20;
        public static List<Figure> FiguresList;
        public static bool AddFigure(FigureTypes shape,MaterialTypes material,double[]sides)
        {
            return true;
        }
    }
}
