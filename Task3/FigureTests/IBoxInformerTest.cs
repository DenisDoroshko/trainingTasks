using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBox;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class IBoxInformerTest
    {
        [DataTestMethod]
        [DataRow(15)]
        [DataRow(10)]
        [DataRow(13)]
        public void ShowQuantity(int figuresNumber)
        {
            //Arange
            int expected = figuresNumber;
            var box = new FigureBox();
            for (var i = 0; i < figuresNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { i, i, i, i }, MaterialTypes.Paper);
                box.AddFigure(figure);
            }
            //Act
            int result = box.ShowQuantity();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(12,2,2,2)]
        [DataRow(32600,100,150,10)]
        [DataRow(434,11,12,13)]
        public void ShowAreaSum(double expected,double firstSide,double secondSide,double thirdSide)
        {
            //Arange
            var box = new FigureBox();
            var firstFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { firstSide, firstSide, firstSide, firstSide }, MaterialTypes.Paper);
            var secondFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { secondSide, secondSide, secondSide, secondSide }, MaterialTypes.Film);
            var thirdFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { thirdSide, thirdSide, thirdSide, thirdSide }, MaterialTypes.Plastic);
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            double result = box.ShowAreaSum();
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(48, 4, 4, 4)]
        [DataRow(4864, 1111, 100, 5)]
        [DataRow(240, 10, 20, 30)]
        public void ShowPerimeterSum(double expected, double firstSide, double secondSide, double thirdSide)
        {
            //Arange
            var box = new FigureBox();
            var firstFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { firstSide, firstSide, firstSide, firstSide }, MaterialTypes.Paper);
            var secondFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { secondSide, secondSide, secondSide, secondSide }, MaterialTypes.Film);
            var thirdFigure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { thirdSide, thirdSide, thirdSide, thirdSide }, MaterialTypes.Plastic);
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            double result = box.ShowPerimeterSum();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
