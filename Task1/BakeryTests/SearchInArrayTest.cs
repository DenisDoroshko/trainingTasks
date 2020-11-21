using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bakery;
using WorkWithBakery;

namespace BakeryTests
{
    [TestClass]
    public class SearchInArrayTest
    {
        [TestMethod]
        public void FindEquals()
        {
            ///Arange
            int expected = 2;
            var firstComposition = new List<Ingredient>(1) { new Ingredient("sugar", 0.5, 2, 70) };
            var seconfComposition = new List<Ingredient>(1) { new Ingredient("sugar", 1, 4, 70) };
            var thirdComposition = new List<Ingredient>(1) { new Ingredient("sugar", 2, 2, 85.5) };
            var fourthComposition = new List<Ingredient>(1) { new Ingredient("sugar", 1, 5, 70) };
            var fifthComposition = new List<Ingredient>(1) { new Ingredient("sugar", 1, 2.5, 30) };
            var compositions = new List<Ingredient>[5] { firstComposition, seconfComposition, thirdComposition, fourthComposition, fifthComposition };
            var products = MakeProducts(compositions);
            var givenComposition = new List<Ingredient>(1) { new Ingredient("sugar", 2, 2, 70) };
            var givenProduct = new Bread("Bread", 10, givenComposition);
            ///Act
            var foundProducts = SearchInArray.FindEquals(products, givenProduct);
            int result = foundProducts.Count;
            ///Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FindByIngredientScope()
        {
            ///Arange
            int expected = 2;
            var firstComposition = new List<Ingredient>(1) { new Ingredient("sugar", 0.5, 2, 70) };
            var seconfComposition = new List<Ingredient>(1) { new Ingredient("flour", 2, 4, 70) };
            var thirdComposition = new List<Ingredient>(1) { new Ingredient("sugar", 2, 2, 85.5) };
            var fourthComposition = new List<Ingredient>(1) { new Ingredient("water", 1, 5, 70) };
            var fifthComposition = new List<Ingredient>(1) { new Ingredient("sugar", 3, 2.5, 30) };
            var compositions = new List<Ingredient>[5] { firstComposition, seconfComposition, thirdComposition, fourthComposition, fifthComposition };
            var products = MakeProducts(compositions);
            ///Act
            var foundProducts = SearchInArray.FindByIngredientScope(products, "sugar", 1.5);
            int result = foundProducts.Count;
            ///Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FindByIngredientsNumber()
        {
            ///Arange
            int expected = 3;
            var firstComposition = new List<Ingredient>(3) { new Ingredient("sugar", 0.5, 2, 70), new Ingredient("water", 0.5, 2, 70), new Ingredient("flour", 0.5, 2, 70) };
            var seconfComposition = new List<Ingredient>(4) { new Ingredient("flour", 2, 4, 70), new Ingredient("sugar", 0.5, 2, 70), new Ingredient("eggs", 0.5, 2, 70), new Ingredient("sugar", 0.5, 2, 70) };
            var thirdComposition = new List<Ingredient>(2) { new Ingredient("sugar", 2, 2, 85.5), new Ingredient("water", 0.5, 2, 70) };
            var fourthComposition = new List<Ingredient>(3) { new Ingredient("water", 1, 5, 70), new Ingredient("sugar", 0.5, 2, 70), new Ingredient("flour", 0.5, 2, 70) };
            var fifthComposition = new List<Ingredient>(1) { new Ingredient("sugar", 3, 2.5, 30) };
            var compositions = new List<Ingredient>[5] { firstComposition, seconfComposition, thirdComposition, fourthComposition, fifthComposition };
            var products = MakeProducts(compositions);
            ///Act
            var foundProducts = SearchInArray.FindByIngredientsNumber(products, 2);
            int result = foundProducts.Count;
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
