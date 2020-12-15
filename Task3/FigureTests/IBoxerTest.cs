using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBox;
using Figures;
using OwnExceptions;

namespace FigureTests
{
    [TestClass]
    public class IBoxerTest
    {
        [TestMethod]
        public void AddFigure_NullFigure()
        {
            //Arange
            bool expected = true;
            Figure addedFigure = null;
            var box = new FigureBox();
            bool result = false;
            //Act
            try
            {
                box.AddFigure(addedFigure);
            }
            catch (ArgumentNullException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(220)]
        [DataRow(51.1)]
        public void AddFigure_AlreadyExistsFigure(double radius)
        {
            //Arange
            bool expected = true;
            Figure addedFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { radius }, MaterialTypes.Plastic);
            var box = new FigureBox();
            box.AddFigure(new PlasticFigure(new Circle(new double[1] { radius })));
            bool result = false;
            //Act
            try
            {
                box.AddFigure(addedFigure);
            }
            catch (AlreadyExistsException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(220)]
        [DataRow(51.1)]
        public void AddFigure_BoxOverfLow(double radius)
        {
            //Arange
            bool expected = true;
            Figure addedFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { radius }, MaterialTypes.Plastic);
            var box = new FigureBox();
            for(var i=0;i<20;i++)
                box.AddFigure(new PlasticFigure(new Circle(new double[1] { i })));
            bool result = false;
            //Act
            try
            {
                box.AddFigure(addedFigure);
            }
            catch (BoxOverfLowException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(20,20,20,1)]
        [DataRow(110, 110, 110, 2)]
        [DataRow(31.5, 31.5, 31.5,3)]
        public void ShowFigure_CorrectNumber(double firtsSide,double secondSide,double thirdSide,int number)
        {
            //Arange
            Figure expected = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firtsSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 20, 20, 20 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 110, 110, 110 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 31.5,31.5, 31.5 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            var result = box.ShowByNumber(number);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(12)]
        [DataRow(10)]
        [DataRow(-1)]
        public void ShowFigure_IncorrectNumber(int number)
        {
            //Arange
            bool expected = true;
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 20, 20, 20 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 110, 110, 110 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 31.5, 31.5, 31.5 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            bool result = false;
            //Act
            try
            {
                box.ShowByNumber(number);
            }
            catch (ArgumentOutOfRangeException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ExtractByNumber_CorrectNumber(int number)
        {
            //Arange
            int expected = 2;
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 20, 20, 20 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 110, 110, 110 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 31.5, 31.5, 31.5 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            box.ExtractByNumber(number);
            int result = box.ShowQuantity();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(14)]
        [DataRow(-12)]
        [DataRow(63)]
        public void ExtractByNumber_IncorrectNumber(int number)
        {
            //Arange
            bool expected = true;
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 20, 20, 20 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 110, 110, 110 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 31.5, 31.5, 31.5 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            bool result = false;
            //Act
            try
            {
                box.ShowByNumber(number);
            }
            catch (ArgumentOutOfRangeException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(50, 50, 50, 1)]
        [DataRow(35.1, 35.1, 35.1, 2)]
        [DataRow(100, 100, 100, 3)]
        public void ReplaceByNumber_CorrectNumber(double firstSide, double secondSide, double thirdSide, int number)
        {
            //Arange
            Figure expected = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firstSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure newFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firstSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 50, 50, 50}, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 35.1, 35.1, 35.1 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 100, 100, 100 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            box.ReplaceByNumber(number,newFigure);
            Figure result = box.ShowByNumber(number);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(50, 50, 50, -10)]
        [DataRow(35.1, 35.1, 35.1, 100)]
        [DataRow(100, 100, 100, 54)]
        public void ReplaceByNumber_IncorrectNumber(double firstSide, double secondSide, double thirdSide, int number)
        {
            //Arange
            bool expected = false;
            Figure newFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firstSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 50, 50, 50 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 35.1, 35.1, 35.1 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 100, 100, 100 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            bool result = box.ReplaceByNumber(number, newFigure);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(20, 20, 20)]
        [DataRow(100, 100, 100)]
        [DataRow(15, 15, 15)]
        public void FindEquivalent_ThereIsFigure(double firstSide, double secondSide, double thirdSide)
        {
            //Arange
            Figure expected = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firstSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure givenFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { firstSide, secondSide, thirdSide }, MaterialTypes.Film);
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 20, 20, 20 }, MaterialTypes.Film);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 100, 100, 100 }, MaterialTypes.Film);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Triangle, new double[3] { 15, 15, 15 }, MaterialTypes.Film);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            Figure result = box.FindEquivalent(givenFigure);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(10)]
        [DataRow(10)]
        [DataRow(10)]
        public void FindEquivalent_ThereIsNotFigure(double radius)
        {
            //Arange
            Figure expected = null;
            Figure givenFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { radius }, MaterialTypes.Plastic);
            Figure firstFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { 20}, MaterialTypes.Plastic);
            Figure secondFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { 100 }, MaterialTypes.Plastic);
            Figure thirdFigure = FigureCreator.CreateFigure(FigureTypes.Circle, new double[1] { 15 }, MaterialTypes.Plastic);
            var box = new FigureBox();
            box.AddFigure(firstFigure);
            box.AddFigure(secondFigure);
            box.AddFigure(thirdFigure);
            //Act
            Figure result = box.FindEquivalent(givenFigure);
            //Assert
            Assert.AreEqual(expected, result);
        }

    }
}
