using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    public interface IBoxGeter
    {
        List<Figure> GetAllCircles();
        List<Figure> GetAllFilmFigures();
        List<Figure> GetNeverPaintedPlasticFigures();
    }
}
