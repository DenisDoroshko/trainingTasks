using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using System.Text.RegularExpressions;
using FigureReadingWriting;
using OwnExceptions;

namespace FiguresBox
{
    /// <summary>
    /// Represents a box with figures
    /// </summary>
    
    public class FigureBox:IBoxer,IBoxGeter,IBoxInformer,IWriterReader
    {
        /// <summary>
        /// Creates an instance of the FiguresBox class
        /// </summary>
        
        public FigureBox()
        {
            figuresList = new List<Figure>(BoxSize);
        }

        /// <summary>
        /// Box size
        /// </summary>
        
        public const int BoxSize = 20;

        /// <summary>
        /// Figures list
        /// </summary>
        
        private List<Figure> figuresList;

        /// <summary>
        /// Add a figure to the list of figures
        /// </summary>
        /// <param name="givenFigure">Specified figure</param>
        /// <returns>True if the operation was completed successfully; otherwise, false</returns>

        public void AddFigure(Figure givenFigure)
        {
            if (givenFigure == null)
            {
                throw new ArgumentNullException();
            }
            if (figuresList.Count >= BoxSize)
            {
                throw new BoxOverfLowException($"The box can only contain {BoxSize} figures");
            }
            foreach(var figure in figuresList)
            {
                if (figure.Equals(givenFigure))
                    throw new AlreadyExistsException();
            }
            figuresList.Add(givenFigure);
        }

        /// <summary>
        /// Shows a figure by number
        /// </summary>
        /// <param name="number">Specified number</param>
        /// <returns>Found figure</returns>

        public Figure ShowByNumber(int number)
        {
            if (number > 0 && number <= figuresList.Count) 
            {
                return figuresList[number-1];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Box doesn't contain such a figure number");
            }
        }

        /// <summary>
        /// Extracts a figure from figures list by number
        /// </summary>
        /// <param name="number">Specified number</param>
        /// <returns>Extracted figure</returns>

        public Figure ExtractByNumber(int number)
        {
            if (number > 0 && number <= figuresList.Count)
            {
                var figure = figuresList[number - 1];
                figuresList.RemoveAt(number - 1);
                return figure;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Box doesn't contain such a figure number");
            }
        }

        /// <summary>
        /// Replaces a figure by the specified number
        /// </summary>
        /// <param name="number">Specified</param>
        /// <param name="newfigure">New figure</param>
        /// <returns>True if the operation was completed successfully; otherwise, false</returns>
        
        public bool ReplaceByNumber(int number,Figure newfigure)
        {
            var isReplaced = false;
            if (number > 0 && number <= figuresList.Count)
            {
                figuresList.RemoveAt(number - 1);
                figuresList.Insert(number - 1,newfigure);
                isReplaced = true;
            }
            return isReplaced;
        }

        /// <summary>
        /// Searches for the figure equivalent
        /// </summary>
        /// <param name="givenFigure">Given figure</param>
        /// <returns>Found figure</returns>
        
        public Figure FindEquivalent(Figure givenFigure)
        {
            var notFound = true;
            Figure equivalentFigure = null;
            for(var i=0;i<figuresList.Count && notFound; i++)
            {
                if (figuresList[i].Equals(givenFigure))
                {
                    equivalentFigure = figuresList[i];
                }
            }
            return equivalentFigure;
        }

        /// <summary>
        /// Searches for all circles in the figures list
        /// </summary>
        /// <returns>Circles</returns>
        
        public List<Figure> GetAllCircles()
        {
            var circles = new List<Figure>();
            foreach(var figure in figuresList)
            {
                if (Regex.IsMatch(figure.Name, "Circle"))
                    circles.Add(figure);
            }
            return circles;
        }

        /// <summary>
        /// Searches for all film figures in the figures list
        /// </summary>
        /// <returns>Film figures</returns>

        public List<Figure> GetAllFilmFigures()
        {
            var filmFigures = new List<Figure>();
            foreach (var figure in figuresList)
            {
                if (Regex.IsMatch(figure.Name, "Film"))
                    filmFigures.Add(figure);
            }
            return filmFigures;
        }

        /// <summary>
        /// Searches for all never painted plastic figures in the figures list
        /// </summary>
        /// <returns>Film figures</returns>

        public List<Figure> GetNeverPaintedPlasticFigures()
        {
            var foundFigures = new List<Figure>();
            foreach (var figure in figuresList)
            {
                if (Regex.IsMatch(figure.Name, "Plastic"))
                {
                    var plasticFigure = (PlasticFigure)figure;
                    if (plasticFigure.IsChangedColor)
                        foundFigures.Add(figure);
                }
            }
            return foundFigures;
        }

        /// <summary>
        /// Shows quantity of figures
        /// </summary>
        /// <returns>The quantity of figures</returns>
        
        public int ShowQuantity()
        {
            return figuresList.Count;
        }

        /// <summary>
        /// Shows the sum of the areas of the figures
        /// </summary>
        /// <returns>Sum of the areas of the figures</returns>
        
        public double ShowAreaSum()
        {
            double areaSum = 0;
            foreach (var figure in figuresList)
            {
                areaSum += figure.Area;
            }
            return areaSum;
        }

        /// <summary>
        /// Shows the sum of the perimeters of the figures
        /// </summary>
        /// <returns>Sum of the perimeters of the figures</returns>

        public double ShowPerimeterSum()
        {
            double perimeterSum = 0;
            foreach (var figure in figuresList)
            {
                perimeterSum += figure.Perimeter;
            }
            return perimeterSum;
        }

        /// <summary>
        /// Saves figures using StreamWtirer
        /// </summary>
        /// <param name="path">File path</param>
        
        public void SaveByStreamWriter(string path)
        {
            StreamReaderWriter.Save(figuresList,path);
        }

        /// <summary>
        /// Saves figures using StreamWtirer by specified material
        /// </summary>
        /// <param name="material">Specified material</param>
        /// <param name="path">File path</param>

        public void SaveByStreamWriter(MaterialTypes material,string path)
        {
            var savedFigures = new List<Figure>();
            foreach(var figure in figuresList)
            {
                if (Regex.IsMatch(figure.Name, material.ToString()))
                    savedFigures.Add(figure);
            }
            StreamReaderWriter.Save(savedFigures, path);
        }

        /// <summary>
        /// Saves figures using XmlWtirer
        /// </summary>
        /// <param name="path">File path</param>

        public void SaveByXmlWriter(string path)
        {
            XmlReaderWriter.Save(figuresList, path);
        }

        /// <summary>
        /// Saves figures using StreamWtirer by specified material
        /// </summary>
        /// <param name="material">Specified material</param>
        /// <param name="path">File path</param>
        
        public void SaveByXmlWriter(MaterialTypes material, string path)
        {
            var savedFigures = new List<Figure>();
            foreach (var figure in figuresList)
            {
                if (Regex.IsMatch(figure.Name, material.ToString()))
                    savedFigures.Add(figure);
            }
            XmlReaderWriter.Save(savedFigures, path);
        }

        /// <summary>
        /// Loads figures using StreamReader
        /// </summary>
        /// <param name="path">File path</param>
        
        public void LoadByStreamReader(string path)
        {
            var figures=StreamReaderWriter.Read(path);
            if (figures.Count <= BoxSize)
            {
                figuresList = figures;
            }
            else
            {
                throw new BoxOverfLowException($"The box can only contain {BoxSize} figures");
            }
        }

        /// <summary>
        /// Loads figures using XmlReader
        /// </summary>
        /// <param name="path">File path</param>

        public void LoadByXmlReader(string path)
        {
            var figures = XmlReaderWriter.Read(path);
            if (figures.Count <= BoxSize)
            {
                figuresList = figures;
            }
            else
            {
                throw new BoxOverfLowException($"The box can only contain {BoxSize} figures");
            }
        }
    }
}
