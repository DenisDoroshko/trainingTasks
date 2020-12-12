using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            //var reader = XmlReader.Create("data.xml");
            //reader.MoveToContent();
            //var data = reader.ReadElementContentAsString();
            //Console.WriteLine(data);
            var fig = new Circle(new double[1] { 5});
            var figPlastic = new PlasticFigure(fig);
            figPlastic.Color = Colors.Blue;
            var fig2 = new Triangle(new double[3] { 3,3,3 });
            var figPlastic2 = new PlasticFigure(figPlastic,fig2);
            Console.WriteLine($"{figPlastic2.Name} {figPlastic2.Area} {figPlastic2.Perimeter} {figPlastic2.Color}");
            List<Figure> figures = new List<Figure>() {figPlastic,figPlastic2 };
      
            using (XmlWriter writer = XmlWriter.Create("employees.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
                
                foreach (var employee in figures)
                {
                    writer.WriteStartElement("user");

                    writer.WriteElementString("Name", employee.Name.ToString());
                    string str="";
                    foreach (var side in employee.Sides)
                        str += $"{side} ";
                    writer.WriteElementString("Sides", str);
                    writer.WriteElementString("Color", employee.Color.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Console.ReadLine();
        }
    }
}
