using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBox;
using Figures;
using FigureReadingWriting;
using System.Collections.Generic;

namespace FigureTests
{
    [TestClass]
    public class IWriterReaderTest
    {
        [DataTestMethod]
        [DataRow(4, 5, 4, 5, "test.xml")]
        [DataRow(15, 20, 15, 20, "test.xml")]
        [DataRow(200, 150, 200, 150, "test.xml")]
        public void SaveByStreamWriter(double firstSide, double secondSide, double thirdSide, double fourthSide,string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure originalFigure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            originalFigure.Color = Colors.Red;
            box.AddFigure(originalFigure);
            //Act
            box.SaveByStreamWriter(filePath);
            var restoredFigures = XmlReaderWriter.Read(filePath);
            bool result = originalFigure.Equals(restoredFigures[0]);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 5, 4, 5, "test.xml")]
        [DataRow(15, 20, 15, 20, "test.xml")]
        [DataRow(200, 150, 200, 150, "test.xml")]
        public void SaveByStreamWriterWithMaterial(double firstSide, double secondSide, double thirdSide, double fourthSide, string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure firstFigure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            Figure secondFigure = new PlasticFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            firstFigure.Color = Colors.Red;
            secondFigure.Color = Colors.Green;
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            //Act
            box.SaveByStreamWriter(MaterialTypes.Paper,filePath);
            var restoredFigures = XmlReaderWriter.Read(filePath);
            bool result = firstFigure.Equals(restoredFigures[0]) && restoredFigures.Count == 1;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 5, 4, 5, "test.xml")]
        [DataRow(15, 20, 15, 20, "test.xml")]
        [DataRow(200, 150, 200, 150, "test.xml")]
        public void SaveByXmlWriter(double firstSide, double secondSide, double thirdSide, double fourthSide, string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure originalFigure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            originalFigure.Color = Colors.Red;
            box.AddFigure(originalFigure);
            //Act
            box.SaveByXmlWriter(filePath);
            var restoredFigures = StreamReaderWriter.Read(filePath);
            bool result = originalFigure.Equals(restoredFigures[0]);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(4, 5, 4, 5, "test.xml")]
        [DataRow(15, 20, 15, 20, "test.xml")]
        [DataRow(200, 150, 200, 150, "test.xml")]
        public void SaveByXmlWriterWithMaterial(double firstSide, double secondSide, double thirdSide, double fourthSide, string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure firstFigure = new PaperFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            Figure secondFigure = new PlasticFigure(new Rectangle(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            firstFigure.Color = Colors.Red;
            secondFigure.Color = Colors.Green;
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            //Act
            box.SaveByXmlWriter(MaterialTypes.Paper, filePath);
            var restoredFigures = StreamReaderWriter.Read(filePath);
            bool result = firstFigure.Equals(restoredFigures[0]) && restoredFigures.Count == 1;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(10, "test.xml")]
        [DataRow(51,"test.xml")]
        [DataRow(138, "test.xml")]
        public void LoadByStreamReader(double radius, string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure firstFigure = new FilmFigure(new Circle(new double[1] { radius }));
            Figure secondFigure = new PlasticFigure(new Circle(new double[1] { radius }));
            var figures = new List<Figure>() { firstFigure, secondFigure };
            //Act
            XmlReaderWriter.Save(figures,filePath);
            box.LoadByStreamReader(filePath);
            bool result = firstFigure.Equals(box.ShowByNumber(1)) && secondFigure.Equals(box.ShowByNumber(2));
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(5, "test.xml")]
        [DataRow(13, "test.xml")]
        [DataRow(1111, "test.xml")]
        public void LoadByXmlReader(double radius, string filePath)
        {
            //Arange
            bool expected = true;
            var box = new FigureBox();
            Figure firstFigure = new PaperFigure(new Circle(new double[1] { radius }));
            Figure secondFigure = new PlasticFigure(new Circle(new double[1] { radius }));
            var figures = new List<Figure>() { firstFigure, secondFigure };
            //Act
            StreamReaderWriter.Save(figures, filePath);
            box.LoadByXmlReader(filePath);
            bool result = firstFigure.Equals(box.ShowByNumber(1)) && secondFigure.Equals(box.ShowByNumber(2));
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
