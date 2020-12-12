using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using FigureReadingWriting;

namespace FiguresBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var fig = new Circle(new double[1] { 5 });
            var figPlastic = new PlasticFigure(fig);
            figPlastic.Color = Colors.Blue;
            var fig2 = new Triangle(new double[3] { 3, 3, 3 });
            var figPlastic2 = new PlasticFigure(figPlastic, fig2);
            Console.WriteLine($"{figPlastic2.Name} {figPlastic2.Area} {figPlastic2.Perimeter} {figPlastic2.Color}");
            List<Figure> figures = new List<Figure>() { figPlastic, figPlastic2 };
            WorkWithXml.SaveWithXmlWriter(figures);
            var f = WorkWithXml.ReadWithXmlReader();
            Console.WriteLine(f.Count);
            foreach (var fi in f)
            {
                Console.WriteLine(fi);
            }
            Console.ReadLine();
        }
    }
}
