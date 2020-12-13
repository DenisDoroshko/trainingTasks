using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using FigureReadingWriting;
using System.Xml;

namespace FiguresBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fig = new Circle(new double[1] { 5 });
            //var figPlastic = new PlasticFigure(fig);
            //figPlastic.Color = Colors.Blue;
            //var fig2 = new Triangle(new double[3] { 3, 3, 3 });
            //var figPlastic2 = new PlasticFigure(figPlastic, fig2);
            //Console.WriteLine($"{figPlastic2.Name} {figPlastic2.Area} {figPlastic2.Perimeter} {figPlastic2.Color}");
            //List<Figure> figures = new List<Figure>() { figPlastic, figPlastic2 };
            //StreamReaderWriter.Save(figures,"figures.xml");
            var f = new double[4] { 3, 3, 3, 3 };
            Console.WriteLine(f.DoubleArrayToString());
            var figures2 = XmlReaderWriter.Read("figures.xml");
            FiguresBox box = new FiguresBox();
            var fig0=FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { 3, 3, 3,3 },MaterialTypes.Film);
            var fig1 = FigureCreator.CreateFigure(FigureTypes.Rectangle, new double[4] { 3, 3, 3, 3 }, MaterialTypes.Paper);
            var fig2 = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 3, 3, 3}, MaterialTypes.Plastic);
            Figure empty = new Circle(new double[1] { 1 });
            var fig3 = new PlasticFigure((FigureDecorator)fig2, empty);
            fig1.Color = Colors.Red;
            box.AddFigure(fig0);
            Console.WriteLine(figures2.Count);
            for (var i = 0; i < 20; i++)
            {
                if (i == 15)
                {
                    Console.WriteLine(box.ShowQuantity());
                    var g = box.ReplaceByNumber(1,fig1);
                    Console.WriteLine(box.ShowByNumber(1));
                    Console.WriteLine(box.ShowQuantity());
                }
                box.AddFigure(figures2[i]);
            }
            //foreach (var fi in figures2)
            //{
            //    Console.WriteLine(fi);
            //}
            //XmlReaderWriter.Save(figures2, "figures2.xml");
            //var f = StreamReaderWriter.Read("figures2.xml");
            //Console.WriteLine(f.Count);
            //foreach (var fi in f)
            //{
            //    Console.WriteLine(fi);
            //}
            Console.ReadLine();
        }
    }
}
