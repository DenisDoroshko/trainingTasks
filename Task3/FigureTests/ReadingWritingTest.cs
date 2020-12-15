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
        [DataRow(15, "test.xml")]
        [DataRow(222, "test.xml")]
        [DataRow(1000.5, "test.xml")]
        public void ReadByStreamReader(double radius, string filePath)
        {
            //Arange
            bool expected = true;
            Figure firstFigure = new FilmFigure(new Circle(new double[1] { radius }));
            Figure secondFigure = new PlasticFigure(new Circle(new double[1] { radius }));
            var originalFigures = new List<Figure>() { firstFigure, secondFigure };
            //Act
            XmlReaderWriter.Save(originalFigures, filePath);
            var restoredFigures=StreamReaderWriter.Read(filePath);
            bool result = originalFigures[0].Equals(restoredFigures[0]) && originalFigures[1].Equals(restoredFigures[1]);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(15,4, "test.xml")]
        [DataRow(222,100, "test.xml")]
        [DataRow(1000.5,135.5, "test.xml")]
        public void ReadByXmlReader(double radius, double side, string filePath)
        {
            //Arange
            bool expected = true;
            Figure firstFigure = new FilmFigure(new Square(new double[4] { side,side,side,side }));
            Figure secondFigure = new PlasticFigure(new Circle(new double[1] { radius }));
            var originalFigures = new List<Figure>() { firstFigure, secondFigure };
            //Act
            StreamReaderWriter.Save(originalFigures, filePath);
            var restoredFigures = XmlReaderWriter.Read(filePath);
            bool result = originalFigures[0].Equals(restoredFigures[0]) && originalFigures[1].Equals(restoredFigures[1]);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(13, "test.xml")]
        [DataRow(155, "test.xml")]
        [DataRow(202, "test.xml")]
        public void SaveByStreamWriter(double side, string filePath)
        {
            //Arange
            bool expected = true;
            Figure originalFigure = new PlasticFigure(new Triangle(new double[3] { side, side, side }));
            originalFigure.Color = Colors.Yellow;
            var figures = new List<Figure>() { originalFigure };
            //Act
            StreamReaderWriter.Save(figures, filePath);
            var restoredFigures = XmlReaderWriter.Read(filePath);
            bool result = originalFigure.Equals(restoredFigures[0]);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, "test.xml")]
        [DataRow(20, "test.xml")]
        [DataRow(200, "test.xml")]
        public void SaveByXmlWriter(double side,string filePath)
        {
            //Arange
            bool expected = true;
            Figure originalFigure = new PlasticFigure(new Square(new double[4] { side, side,side, side }));
            originalFigure.Color = Colors.Black;
            var figures = new List<Figure>() { originalFigure };
            //Act
            XmlReaderWriter.Save(figures,filePath);
            var restoredFigures = StreamReaderWriter.Read(filePath);
            bool result = originalFigure.Equals(restoredFigures[0]);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
