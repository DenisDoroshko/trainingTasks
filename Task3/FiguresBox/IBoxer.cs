using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    /// <summary>
    /// The interface for main box functions
    /// </summary>
    
    interface IBoxer
    {
        /// <summary>
        /// Add a figure to the list of figures
        /// </summary>
        /// <param name="givenFigure">Specified figure</param>
        /// <returns>True if the operation was completed successfully; otherwise, false</returns>

        bool AddFigure(Figure givenFigure);

        /// <summary>
        /// Shows a figure by number
        /// </summary>
        /// <param name="number">Specified number</param>
        /// <returns>Found figure</returns>

        Figure ShowByNumber(int number);


        /// <summary>
        /// Extracts a figure from figures list by number
        /// </summary>
        /// <param name="number">Specified number</param>
        /// <returns>Extracted figure</returns>

        Figure ExtractByNumber(int number);

        /// <summary>
        /// Replaces a figure by the specified number
        /// </summary>
        /// <param name="number">Specified</param>
        /// <param name="newfigure">New figure</param>
        /// <returns>True if the operation was completed successfully; otherwise, false</returns>

        bool ReplaceByNumber(int number, Figure newfigure);

        /// <summary>
        /// Searches for the figure equivalent
        /// </summary>
        /// <param name="givenFigure">Given figure</param>
        /// <returns>Found figure</returns>

        Figure FindEquivalent(Figure givenFigure);
    }
}
