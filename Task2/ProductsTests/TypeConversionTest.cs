using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace ProductsTests
{
    [TestClass]
    public class TypeConversionTest
    {
        [DataTestMethod]
        [DataRow(12300, 6, 18, 2.5)]
        [DataRow(3000, 10, 2.5, 0.5)]
        [DataRow(84000, 120, 5, 2)]
        public void ConversionToInt(int expected, int value1, double value2, double value3)
        {
            //Arange
            Clothes product = new Clothes("Coat", value1, value2, value3);
            //Act
            int result = (int)product;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(123, 6, 18, 2.5)]
        [DataRow(30, 10, 2.5, 0.5)]
        [DataRow(840, 120, 5, 2)]
        public void ConversionToDouble(double expected, int value1, double value2, double value3)
        {
            //Arange
            Furniture product = new Furniture("Table", value1, value2, value3);
            //Act
            double result = (double)product;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConversionFoodToClothes()
        {
            //Arange
            Clothes expected = new Clothes("Default", 10, 10, 10);
            Food product = new Food("Default", 10, 10, 10);
            //Act
            var result = (Clothes)product;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConversionFurnitureToFood()
        {
            //Arange
            Food expected = new Food("Default", 10, 10, 10);
            Furniture product = new Furniture("Default", 10, 10, 10);
            //Act
            var result = (Food)product;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
