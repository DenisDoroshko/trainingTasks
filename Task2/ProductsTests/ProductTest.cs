using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;
using OwnExceptions;

namespace ProductsTests
{
    [TestClass]
    public class ProductTest
    {
        [DataTestMethod]
        [DataRow(5.1,6, 3.5, 1.6)]
        [DataRow(3.2,18, 2.7, 0.5)]
        [DataRow(22,20, 10.5, 11.5)]
        public void GettingUnitPrice(double expected,int value1, double value2, double value3)
        {
            //Arange
            Food product = new Food("Bread", value1, value2, value3);
            //Act
            double result = product.UnitPrice;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(308, 10, 25.8, 5)]
        [DataRow(37800, 2100, 15.5, 2.5)]
        [DataRow(1780.6, 29, 60.5, 0.9)]
        public void GettingAllPrice(double expected, int value1, double value2, double value3)
        {
            //Arange
            Clothes product = new Clothes("T-shirt", value1, value2, value3);
            //Act
            double result = product.AllPrice;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(18, 22.5, 2.8, 8,22.5,2.8)]
        [DataRow(130, 121.27, 9.45, 120, 129.5, 10)]
        [DataRow(20, 50.5, 2.5, 10, 78.5, 2.2)]
        public void SummOfProductsWithCorrectProducts(int  value1, double value2, double value3,int value4,
            double value5,double value6)
        {
            //Arange
            Furniture expected = new Furniture("Chair",value1,value2,value3);
            Furniture firstProduct = new Furniture("Chair", value4, value5, value6);
            Furniture secondProduct = new Furniture("Chair", 10, 22.5, 2.8);
            //Act
            var  result = firstProduct+secondProduct;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(18, 22.5, 2.8)]
        [DataRow(130, 121.27, 9.45)]
        [DataRow(20, 50.5, 2.5)]
        public void SummOfProductsWithIncorrectProducts(int value1, double value2, double value3)
        {
            //Arange
            bool expected = true;
            Furniture firstProduct = new Furniture("Table", value1, value2, value3);
            Furniture secondProduct = new Furniture("Chair", 10, 22.5, 2.8);
            bool result = false;
            //Act
            try
            {
                var product = firstProduct + secondProduct;
            }
            catch(NotEqualNamesException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(23,31,8)]
        [DataRow(2220, 2320, 100)]
        [DataRow(256, 310, 54)]
        public void SubtractionOfProductsWithCorrectNumber(int value1,int value2, int value3)
        {
            //Arange
            Furniture expected = new Furniture("Chair", value1, 10, 10);
            Furniture firstProduct = new Furniture("Chair", value2, 10, 10);
            //Act
            var result = firstProduct - value3;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(44, 100)]
        [DataRow(2000, 3500)]
        [DataRow(430, 431)]
        public void SubtractionOfProductsWithIncorrectNumber(int value1, int value2)
        {
            //Arange
            bool expected = true;
            Furniture firstProduct = new Furniture("Chair", value1, 10, 10);
            bool result = false;
            //Act
            try
            {
                var product = firstProduct - value2;
            }
            catch (IncorrectNumberException)
            {
                result = true;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Type: Furniture, Name: Table, Number:15, Purchase price:58, Mark up:12,6", "Table",15, 58, 12.6)]
        [DataRow("Type: Furniture, Name: Chair, Number:30, Purchase price:114,5, Mark up:5,7", "Chair",30, 114.5, 5.7)]
        [DataRow("Type: Furniture, Name: Bed, Number:22, Purchase price:320, Mark up:10,5", "Bed",22, 320, 10.5)]
        public void ConvertToString(string expected,string value1,int value2, double value3, double value4)
        {
            //Arange
            Furniture product = new Furniture(value1, value2, value3, value4);
            //Act
            string result = product.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(true,"Coat", 25, 60, 12, "Coat", 25, 60, 12)]
        [DataRow(false,"Hat", 29, 12.5, 5, "Hat", 28, 60, 12)]
        [DataRow(false,"T-shirt", 1000, 15.5, 3, "Shirt", 1000, 15.5, 3)]

        public void EqualsMethod(bool expected,string value1, int value2, double value3, double value4, string value5, int value6, double value7, double value8)
        {
            //Arange
            Clothes firstProduct = new Clothes(value1, value2, value3, value4);
            Clothes secondProduct = new Clothes(value5, value6, value7, value8);
            //Ac
            bool result = firstProduct.Equals(secondProduct);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(7, "Bread", 16, 4.5, 0.5)]
        [DataRow(10, "Joice", 30, 2.2, 0.6)]
        [DataRow(34, "Milk", 100, 3.5, 1)]
        public void GetHashCode(int expected, string value1, int value2, double value3, double value4)
        {
            //Arange
            Food product = new Food(value1, value2, value3, value4);
            //Act
            int result = product.GetHashCode();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
