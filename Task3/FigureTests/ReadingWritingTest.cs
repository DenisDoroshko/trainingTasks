using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FigureReadingWriting;
using Figures;
using System.Collections.Generic;

namespace FigureTests
{
    [TestClass]
    public class ReadingWritingTest
    {
        [DataTestMethod]
        [DataRow("Circle Plastic", "10", "Orange", 10)]
        [DataRow("Circle Plastic", "100", "Orange", 100)]
        [DataRow("Circle Plastic", "25,5", "Orange", 25.5)]
        public void CreateFigureFromStrings(string name,string sides,string color,double radius)
        {
            //Arange
            Figure expected = new PlasticFigure(new Circle(new double[1] { radius}));
            expected.Color = Colors.Orange;
            //Act
            Figure result = FigureConverter.CreateFromStrings(name,sides,color);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(3, 4, 5, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>3 4 5 </Sides><Color> Blue </Color></Figure></Figures> ")]
        [DataRow(15, 16, 17, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>15 16 17 </Sides><Color> Blue </Color></Figure></Figures> ")]
        [DataRow(20, 24, 26, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>20 24 26 </Sides><Color> Blue </Color></Figure></Figures> ")]
        public void ReadByStreamReader(double firstSide,double secondSide,double thirdSide,string filePath, string xmlString)
        {
            //Arange
            Figure expected = new PlasticFigure(new Triangle(new double[3] { firstSide, secondSide, thirdSide }));
            expected.Color = Colors.Blue;
            using (var sw = new StreamWriter(filePath))
            {
                sw.Write(xmlString);
            }
            //Act
            var figures=StreamReaderWriter.Read(filePath);
            var result = figures[0];
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(3, 4, 5, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>3 4 5 </Sides><Color> Blue </Color></Figure></Figures> ")]
        [DataRow(15, 16, 17, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>15 16 17 </Sides><Color> Blue </Color></Figure></Figures> ")]
        [DataRow(20, 24, 26, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures><Figure><Name> Triangle Plastic </Name><Sides>20 24 26 </Sides><Color> Blue </Color></Figure></Figures> ")]
        public void ReadByXmlReader(double firstSide, double secondSide, double thirdSide, string filePath, string xmlString)
        {
            //Arange
            Figure expected = new PlasticFigure(new Triangle(new double[3] { firstSide, secondSide, thirdSide }));
            expected.Color = Colors.Blue;
            using (var sw = new StreamWriter(filePath))
            {
                sw.Write(xmlString);
            }
            //Act
            var figures = XmlReaderWriter.Read(filePath);
            var result = figures[0];
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 5, 4,5, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>4 5 4 5 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        [DataRow(15, 20, 15,20, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>15 20 15 20 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        [DataRow(200, 150, 200,150, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>200 150 200 150 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        public void SaveByStreamWriter(double firstSide, double secondSide, double thirdSide,double fourthSide,
            string filePath, string expected)
        {
            //Arange
            Figure figure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide,fourthSide }));
            figure.Color = Colors.Red;
            var figures = new List<Figure>() { figure};
            string result = "";
            //Act
            StreamReaderWriter.Save(figures, filePath);
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result += sr.ReadLine();
                }
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(4, 5, 4, 5, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>4 5 4 5 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        [DataRow(15, 20, 15, 20, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>15 20 15 20 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        [DataRow(200, 150, 200, 150, "test.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?><Figures>  <Figure>    <Name>Rectangle Plastic</Name>    <Sides>200 150 200 150 </Sides>    <Color>Red</Color>  </Figure></Figures>")]
        public void SaveByXmlWriter(double firstSide, double secondSide, double thirdSide, double fourthSide,
            string filePath, string expected)
        {
            //Arange
            Figure figure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            figure.Color = Colors.Red;
            var figures = new List<Figure>() { figure };
            string result = "";
            //Act
            XmlReaderWriter.Save(figures, filePath);
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result += sr.ReadLine();
                }
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
