using System.Collections.Generic;
using Figures;
using System.Xml;

namespace FigureReadingWriting
{
    /// <summary>
    /// Provides methods for reading and writing xml files using XmlReader and XmlWriter
    /// </summary>

    public static class XmlReaderWriter
    {

        /// <summary>
        /// Saves figures to a xml file
        /// </summary>

        public static void Save(List<Figure> figures, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Figures");
                foreach (var figure in figures)
                {
                    writer.WriteStartElement("Figure");
                    writer.WriteElementString("Name", figure.Name);
                    writer.WriteElementString("Sides", figure.Sides.DoubleArrayToString());
                    writer.WriteElementString("Color", figure.Color.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Reads figures from a xml file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of figures</returns>

        public static List<Figure> Read(string path)
        {
            var figures = new List<Figure>();
            using (XmlReader reader = XmlReader.Create(path))
            {
                string name = null;
                string sides = null;
                string color = null;
                while (reader.Read())
                {
                    switch (reader.LocalName)
                    {
                        case "Name":
                            name = reader.ReadString();
                            break;
                        case "Sides":
                            sides = reader.ReadString();
                            break;
                        case "Color":
                            color = reader.ReadString();
                            break;
                    }
                    if (name != null && sides != null && color != null)
                    {
                        var figure = FigureConverter.CreateFromStrings(name, sides, color);
                        if (figure != null)
                        {
                            figures.Add(figure);
                            name = null;
                            sides = null;
                            color = null;
                        }
                    }
                }
                return figures;
            }
        }
    }
}
