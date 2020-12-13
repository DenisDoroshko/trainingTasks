using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Provides method for creating a figure
    /// </summary>

    public static class FigureCreator
    {
        /// <summary>
        /// Creates a figure
        /// </summary>
        /// <param name="shape">Type of a figure</param>
        /// <param name="sides">Sides of a figure</param>
        /// <param name="material">Material of a figure</param>
        /// <returns>Figure</returns>
        
        public static Figure CreateFigure(FigureTypes shape, double[] sides, MaterialTypes material)
        {
            var emptyFigure = MakeEmptyFigure(shape, sides);
            var figureWithMaterial = MakeFigureWithMaterial(emptyFigure, material);
            return figureWithMaterial;
        }

        /// <summary>
        /// Creates empty figure
        /// </summary>
        /// <param name="shape">Type of a figure</param>
        /// <param name="sides">Sides of a figure</param>
        /// <returns>Empty figure</returns>
        
        private static Figure MakeEmptyFigure(FigureTypes shape, double[] sides)
        {
            Figure figure = null;
            switch (shape)
            {
                case FigureTypes.Circle:
                    figure = new Circle(sides);
                    break;
                case FigureTypes.Triangle:
                    figure = new Triangle(sides);
                    break;
                case FigureTypes.Square:
                    figure = new Square(sides);
                    break;
                case FigureTypes.Rectangle:
                    figure = new Rectangle(sides);
                    break;
            }
            return figure;
        }

        /// <summary>
        /// Creates a figure with a material
        /// </summary>
        /// <param name="figure">Name of a figure</param>
        /// <param name="material">Material of a figure</param>
        /// <returns>Figure with a material</returns>
        
        private static Figure MakeFigureWithMaterial(Figure figure, MaterialTypes material)
        {
            Figure figureWithMaterial = null;
            switch (material)
            {
                case MaterialTypes.Paper:
                    figureWithMaterial = new PaperFigure(figure);
                    break;
                case MaterialTypes.Plastic:
                    figureWithMaterial = new PlasticFigure(figure);
                    break;
                case MaterialTypes.Film:
                    figureWithMaterial = new FilmFigure(figure);
                    break;
            }
            return figureWithMaterial;
        }
    }
}
