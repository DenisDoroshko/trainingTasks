using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FigureReadingWriting
{
    /// <summary>
    /// Provides method for creating a figure from strings
    /// </summary>

    public static class FigureConverter
    {
        /// <summary>
        /// Creates a figure from strings
        /// </summary>
        /// <param name="name">Figure name</param>
        /// <param name="stringSides">Figure sides</param>
        /// <param name="stringColor">Figure color</param>
        /// <returns>Figure</returns>

        public static Figure CreateFromStrings(string name, string stringSides, string stringColor)
        {
            string[] names = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            FigureTypes shape;
            MaterialTypes material;
            Colors color;
            FigureDecorator figureWithMaterial = null;
            if (Enum.TryParse(names[0], out shape) && Enum.TryParse(names[1], out material) &&
                Enum.TryParse(stringColor, out color))
            {
                var sides = ParseSides(stringSides);
                Figure figure = CreateEmptyFigure(shape, sides);
                figureWithMaterial = CreateFigureWithMaterial(figure, material, color);
            }
            return figureWithMaterial;
        }

        /// <summary>
        /// Creates a empty figure
        /// </summary>
        /// <param name="shape">Type of a figure</param>
        /// <param name="sides">Sides of a figure</param>
        /// <returns>Empty figure</returns>
        
        private static Figure CreateEmptyFigure(FigureTypes shape, double[] sides)
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
        /// <param name="figure">Initial empty figure</param>
        /// <param name="material">Type of material</param>
        /// <param name="color">Color of a figure</param>
        /// <returns>Figure wiht a material</returns>
        
        private static FigureDecorator CreateFigureWithMaterial(Figure figure, MaterialTypes material, Colors color)
        {
            FigureDecorator figureWithMaterial = null;
            switch (material)
            {
                case MaterialTypes.Paper:
                    figureWithMaterial = new PaperFigure(figure);
                    figureWithMaterial.Color = color;
                    break;
                case MaterialTypes.Plastic:
                    figureWithMaterial = new PlasticFigure(figure);
                    figureWithMaterial.Color = color;
                    break;
                case MaterialTypes.Film:
                    figureWithMaterial = new FilmFigure(figure);
                    break;
            }
            return figureWithMaterial;
        }

        /// <summary>
        /// Converts sides from string to double
        /// </summary>
        /// <param name="stringSides">String sides</param>
        /// <returns>Array of figure sides</returns>
        
        private static double[] ParseSides(string stringSides)
        {
            string[] values = stringSides.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] sides = new double[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                double.TryParse(values[i], out sides[i]);
            }
            return sides;
        }
    }
}
