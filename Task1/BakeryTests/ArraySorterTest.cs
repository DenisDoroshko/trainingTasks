using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery;
using WorkWithBakery;
using System.Collections.Generic;

namespace BakeryTests
{
    [TestClass]
    public class ArraySorterTest
    {
        [DataTestMethod]
        [DataRow(10,45.5,60,70,20.5)]
        [DataRow(5, 0, 120, 23.8, 101.4)]
        [DataRow(5.2, 34.2, 35.9, 34.5, 12.2)]
        public void SortByCalories(double value1,double value2,double value3,double value4,double value5)
        {
            ///Arange
            bool expected = true;
            var firstComposition = new List<Ingredient>(1) {new Ingredient("water",1,1, value1) };
            var seconfComposition = new List<Ingredient>(1) { new Ingredient("water", 1, 1, value2) };
            var thirdComposition = new List<Ingredient>(1) { new Ingredient("water", 1, 1, value3) };
            var fourthComposition = new List<Ingredient>(1) { new Ingredient("water", 1, 1, value4) };
            var fifthComposition = new List<Ingredient>(1) { new Ingredient("water", 1, 1, value5) };
            var compositions = new List<Ingredient>[5] { firstComposition, seconfComposition, thirdComposition, fourthComposition, fifthComposition };
            var products = MakeProducts(compositions);
            bool result = true;
            ///Act
            var sortedProducts = ArraySorter.SortByCalories(products);
            for(var i = 0; i < products.Count - 1; i++)
            {
                if (sortedProducts[i].Calories > sortedProducts[i + 1].Calories)
                {
                    result = false;
                }
            }
            ///Assert
            Assert.AreEqual(expected,result);
        }

        [DataTestMethod]
        [DataRow(5, 15, 20, 25, 35)]
        [DataRow(12.5, 16.1, 21.6, 4.2, 3.7)]
        [DataRow(4.6, 5.9, 3.1, 3.1, 1.5)]
        public void SortByPrice(double value1, double value2, double value3, double value4, double value5)
        {
            ///Arange
            bool expected = true;
            var firstComposition = new List<Ingredient>(1) { new Ingredient("water", 1, value1, 1) };
            var seconfComposition = new List<Ingredient>(1) { new Ingredient("water", 1, value2, 1) };
            var thirdComposition = new List<Ingredient>(1) { new Ingredient("water", 1, value3, 1) };
            var fourthComposition = new List<Ingredient>(1) { new Ingredient("water", 1, value4, 1) };
            var fifthComposition = new List<Ingredient>(1) { new Ingredient("water", 1, value5, 1) };
            var compositions = new List<Ingredient>[5] { firstComposition, seconfComposition, thirdComposition, fourthComposition, fifthComposition };
            var products = MakeProducts(compositions);
            bool result = true;
            ///Act
            var sortedProducts = ArraySorter.SortByPrice(products);
            for (var i = 0; i < products.Count - 1; i++)
            {
                if (sortedProducts[i].Price > sortedProducts[i + 1].Price)
                {
                    result = false;
                }
            }
            ///Assert
            Assert.AreEqual(expected, result);
        }
        private List<BakeryProduct> MakeProducts(List<Ingredient>[] compositions)
        {
            var products = new List<BakeryProduct>();
            products.Add(new Bread("NewBread", 10, compositions[0]));
            products.Add(new Baton("NewBaton", 10, compositions[1]));
            products.Add(new Bun("NewBun", 10, compositions[2]));
            products.Add(new Pie("Newpie", 10, compositions[3]));
            products.Add(new Cake("NewCake", 10, compositions[4]));
            return products;
        }
    }
}
