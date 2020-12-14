using System.Collections.Generic;
using Figures;
using System.Xml;
using System.IO;

namespace FigureReadingWriting
{
    /// <summary>
    /// Provides methods for reading and writing xml files using StreamReader and StreamWriter
    /// </summary>
    
    public static class StreamReaderWriter
    {
        /// <summary>
        /// Reads figures from a xml file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of figures</returns>

        public static List<Figure> Read(string path)
        {
            var figures = new List<Figure>();
            XmlDocument document = new XmlDocument();
            using (StreamReader sr = new StreamReader(path))
            {
                document.Load(sr);

            }
            XmlElement root = document.DocumentElement;
            foreach (XmlNode figureNode in root)
            {
                string name = null;
                string sides = null;
                string color = null;
                foreach (XmlNode propertyNode in figureNode.ChildNodes)
                {
                    switch (propertyNode.Name)
                    {
                        case "Name":
                            name = propertyNode.InnerText;
                            break;
                        case "Sides":
                            sides = propertyNode.InnerText;
                            break;
                        case "Color":
                            color = propertyNode.InnerText;
                            break;
                    }
                    if (name != null && sides != null && color != null)
                    {
                        var figure = FigureConverter.CreateFromStrings(name, sides, color);
                        if (figure != null)
                            figures.Add(figure);
                    }
                }
            }
            return figures;
        }

        /// <summary>
        /// Saves figures to a xml file
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <param name="path">File path</param>

        public static void Save(List<Figure> figures, string path)
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("Figures");
            document.AppendChild(root);
            foreach (var figure in figures)
            {
                var figureNode = document.CreateElement("Figure");
                root.AppendChild(figureNode);
                FillFigureNode(document, figureNode, "Name", figure.Name);
                FillFigureNode(document, figureNode, "Sides", figure.Sides.DoubleArrayToString());
                FillFigureNode(document, figureNode, "Color", figure.Color.ToString());
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                document.Save(sw);
            }
        }

        /// <summary>
        /// Fills nodes of xml document
        /// </summary>
        /// <param name="document">Xml-document</param>
        /// <param name="figureNode">Figure node</param>
        /// <param name="name">Name of a node</param>
        /// <param name="value">Value of a node</param>
        
        private static void FillFigureNode(XmlDocument document,XmlElement figureNode,string name,string value)
        {
            XmlElement propertyNode= document.CreateElement(name);
            figureNode.AppendChild(propertyNode);
            XmlText nodeValue = document.CreateTextNode(value);
            propertyNode.AppendChild(nodeValue);
        }
    }
}
