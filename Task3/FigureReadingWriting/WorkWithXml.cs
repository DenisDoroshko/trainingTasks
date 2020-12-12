using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Figures;

namespace FigureReadingWriting
{
    public static class WorkWithXml
    {
        public static void SaveWithXmlWriter(List<Figure> figures)
        {
            using (XmlWriter writer = XmlWriter.Create("figures.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Figures");
                foreach (var figure in figures)
                {
                    string stringSides = "";
                    foreach (var side in figure.Sides)
                        stringSides += $"{side} ";
                    writer.WriteStartElement("Figure");
                    writer.WriteElementString("Name", figure.Name.ToString());
                    writer.WriteElementString("Sides", stringSides);
                    writer.WriteElementString("Color", figure.Color.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public static List<Figure> ReadWithXmlReader()
        {
            var figures = new List<Figure>();
            using (XmlReader reader = XmlReader.Create("figures.xml"))
            {
                string name="";
                string sides="";
                string color="";
                while (reader.Read())
                {
                    Console.WriteLine(reader.LocalName);
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
                            Console.WriteLine($"{name} {sides} {color}");
                            figures.Add(CreateFigure(name,sides,color));
                            break;
                    }
                }
                return figures;
            }
        }
        private static Figure CreateFigure(string name, string stringSides, string stringColor)
        {
            string[] names = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            FigureTypes shape;
            MaterialTypes material;
            Colors color;
            FigureDecorator figureWithMaterial = null;
            if (Enum.TryParse(names[0], out shape) && Enum.TryParse(names[1], out material) && Enum.TryParse(stringColor, out color))
            {
                var sides = ParseSides(stringSides);
                Figure figure = CreateEmptyFigure(shape, sides);
                figureWithMaterial = CreateFigureWithMaterial(figure,material,color);
            }
            return figureWithMaterial;
        }
        private static Figure CreateEmptyFigure(FigureTypes shape,double[] sides)
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
                    figure = new Circle(sides);
                    break;
                case FigureTypes.Rectangle:
                    figure = new Circle(sides);
                    break;
            }
            return figure;
        }
        public static FigureDecorator CreateFigureWithMaterial(Figure figure,MaterialTypes material,Colors color)
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
                    figureWithMaterial = new PlasticFigure(figure); ///////Add Film
                    break;
            }
            return figureWithMaterial;
        }
        private static double[] ParseSides(string stringSides)
        {
            string[] values = stringSides.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] sides = new double[values.Length];
            for(var i = 0; i < values.Length; i++)
            {
                double.TryParse(values[i], out sides[i]);
            }
            return sides;
        }
    }
}