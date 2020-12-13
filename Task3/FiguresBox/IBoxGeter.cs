using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    /// <summary>
    /// The interface for getting the specified figures
    /// </summary>
    
    public interface IBoxGeter
    {

        /// <summary>
        /// Searches for all circles in the figures list
        /// </summary>
        /// <returns>Circles</returns>

        List<Figure> GetAllCircles();


        /// <summary>
        /// Searches for all film figures in the figures list
        /// </summary>
        /// <returns>Film figures</returns>

        List<Figure> GetAllFilmFigures();


        /// <summary>
        /// Searches for all never painted plastic figures in the figures list
        /// </summary>
        /// <returns>Film figures</returns>

        List<Figure> GetNeverPaintedPlasticFigures();
    }
}
