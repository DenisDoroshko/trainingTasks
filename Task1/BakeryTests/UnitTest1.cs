using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery;
using WorkWithBakery;
using System.Collections.Generic;

namespace BakeryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortByCalories()
        {
            List<Ingredient> composition = new List<Ingredient>();
            BakeryProduct product = new Bread("NewBread", 10, composition);
        }
    }
}
