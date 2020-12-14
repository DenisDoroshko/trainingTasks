using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;
using OwnExceptions;
namespace FigureTests
{
    [TestClass]
    public class FigureTest
    {
        [DataTestMethod]
        [DataRow(2, 5, 6, 7)]
        [DataRow(15, 100, 150, 160)]
        [DataRow(7, 35, 40, 45)]
        public void CutFigureFromOtherFigureCorrectFigure(double radius,double firstSide, double secondSide,double thirdSide)
        {
            //Arange
            Figure expected = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { radius }, MaterialTypes.Plastic);
            Figure originalEmptyFigure = new Triangle(new double[3] { firstSide, secondSide, thirdSide });
            PlasticFigure originalFigure = new PlasticFigure(originalEmptyFigure);
            Figure newEmptyFigure = new Circle(new double[1] { radius });
            //ActfirstSidesecondSide
            Figure newPlasticfigure = new PlasticFigure(originalFigure, newEmptyFigure);
            //Assert
            Assert.AreEqual(expected, newPlasticfigure);
        }

        [DataTestMethod]
        [DataRow(60, 3, 4, 3,4)]
        [DataRow(10, 2, 2, 2,2)]
        [DataRow(211, 50.5, 61.5, 50.5,61.5)]
        public void CutFigureFromOtherFigureBigNewFigure(double radius, double firstSide, double secondSide, double thirdSide,double fourthSide)
        {
            //Arange
            bool expected = true;
            Figure originalEmptyFigure = new Rectangle(new double[4] { firstSide, secondSide, thirdSide,fourthSide });
            PlasticFigure originalFigure = new PlasticFigure(originalEmptyFigure);
            Figure newEmptyFigure = new Circle(new double[1] { radius });
            bool result = false;
            //Act
            try
            {
                Figure newPlasticfigure = new PlasticFigure(originalFigure, newEmptyFigure);
            }
            catch (CutFigureException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 4, 4, 4)]
        [DataRow(14.5, 14.5, 14.5, 14.5)]
        [DataRow(20,20,20,20)]
        public void CreateFigureByFigureCreator(double firstSide, double secondSide, double thirdSide, double fourthSide)
        {
            //Arange
            Figure expected = new FilmFigure(new Square(new double[4] { firstSide, secondSide, thirdSide, fourthSide }));
            //Act
            Figure result = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { firstSide, secondSide, thirdSide, fourthSide }, MaterialTypes.Film);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(25,5, 5, 5, 5)]
        [DataRow(3721,61, 61, 61, 61)]
        [DataRow(841,29, 29, 29, 29)]
        public void CalculateArea(double expected,double firstSide, double secondSide, double thirdSide, double fourthSide)
        {
            //Arange
            Figure figure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { firstSide, secondSide, thirdSide, fourthSide }, MaterialTypes.Paper);
            //Act
            double result = figure.Area;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(1400,35, 40, 35, 40)]
        [DataRow(690,23, 30, 23, 30)]
        [DataRow(150,15, 10, 15, 10)]
        public void CalculatePerimeter(double expected, double firstSide, double secondSide, double thirdSide, double fourthSide)
        {
            //Arange
            Figure figure = FigureCreator.CreateFigure(FigureTypes.Rectangle, new double[4] { firstSide, secondSide, thirdSide, fourthSide }, MaterialTypes.Paper);
            //Act
            double result = figure.Perimeter;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
