using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBox;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class IBoxGeterTest
    {
        [DataTestMethod]
        [DataRow(10,10)]
        [DataRow(15,5)]
        [DataRow(5,8)]
        public void GetAllCircles(int circlesNumber,int otherNumber)
        {
            //Arange
            int expected = circlesNumber;
            var box = new FigureBox();
            for (var i = 0; i < circlesNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { i }, MaterialTypes.Plastic);
                box.AddFigure(figure);
            }
            for (var i = 0; i < otherNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Square, new double[4] { i,i,i,i}, MaterialTypes.Film);
                box.AddFigure(figure);
            }
            //Act
            int result = (box.GetAllCircles()).Count;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(6, 6)]
        [DataRow(5, 15)]
        [DataRow(3, 3)]
        public void GetAllFilmFigures(int filmNumber, int otherNumber)
        {
            //Arange
            int expected = filmNumber;
            var box = new FigureBox();
            for (var i = 0; i < filmNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Rectangle, new double[4] {i,i,i, i }, MaterialTypes.Film);
                box.AddFigure(figure);
            }
            for (var i = 0; i < otherNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { i, i, i }, MaterialTypes.Plastic);
                box.AddFigure(figure);
            }
            //Act
            int result = (box.GetAllFilmFigures()).Count;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(6, 6)]
        [DataRow(5, 15)]
        [DataRow(3, 3)]
        public void GetNeverPaintedPlasticFigures(int paintedNumber, int otherNumber)
        {
            //Arange
            int expected = paintedNumber;
            var box = new FigureBox();
            for (var i = 0; i < paintedNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Rectangle, new double[4] { i, i, i, i }, MaterialTypes.Plastic);
                figure.Color = Colors.White;
                box.AddFigure(figure);
            }
            for (var i = 0; i < otherNumber; i++)
            {
                var figure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { i, i, i }, MaterialTypes.Plastic);
                box.AddFigure(figure);
            }
            //Act
            int result = (box.GetNeverPaintedPlasticFigures()).Count;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
