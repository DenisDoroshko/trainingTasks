using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresBox
{
    /// <summary>
    /// The interface for showing information about figures
    /// </summary>
    
    public interface IBoxInformer
    {

        /// <summary>
        /// Shows quantity of figures
        /// </summary>
        /// <returns>The quantity of figures</returns>
        
        int ShowQuantity();


        /// <summary>
        /// Shows the sum of the areas of the figures
        /// </summary>
        /// <returns>Sum of the areas of the figures</returns>

        double ShowAreaSum();

        /// <summary>
        /// Shows the sum of the perimeters of the figures
        /// </summary>
        /// <returns>Sum of the perimeters of the figures</returns>

        double ShowPerimeterSum();
    }
}
