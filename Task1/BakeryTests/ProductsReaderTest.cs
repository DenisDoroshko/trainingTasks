using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Bakery;
namespace BakeryTests
{
    [TestClass]
    public class ProductsReaderTest
    {
        [DataTestMethod]
        [DataRow("Bread \"Delicious\" 10 pcs\n" +
            "Rye flour 5 kg 10 r 350 J\n" +
            "Water 2 kg 2 r 0 J\n" +
            "Sugar 0.5 kg 2 r 200 J\n" +
            "Baton \"Minski\" 20 pcs\n" +
            "Wheat flour 10.5 kg 15 r 450 J\n" +
            "Water 0.5 kg 3 r 0 J\n" +
            "Bun \"Tasty\" 5 pcs\n" +
            "Wheat flour 2 kg 5 r 450 J\n" +
            "Water 2 kg 3 r 0 J", "Type: Bread Name: \"Delicious\" Produced Number:10 Price: 22 Calories: 352\n" +
            "Type: Baton Name: \"Minski\" Produced Number:20 Price: 11 Calories: 18\n" +
            "Type: Bun Name: \"Tasty\" Produced Number:5 Price: 8,5 Calories: 450\n", "testProducts.txt")]
        public void GetProductsFromFile(string dataLines,string expectedString,string path)
        {
            //Arange
            string expected = expectedString;
            using (var sw = new StreamWriter(path))
            {
                sw.Write(dataLines);
            }
            //Act
            var products = ProductsReader.GetProducts(path);
            string result = "";
            foreach (var product in products)
            {
                result += $"{product}\n";
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
