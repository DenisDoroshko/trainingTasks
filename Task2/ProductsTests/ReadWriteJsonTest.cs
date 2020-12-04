using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;
using WorkWithJson;
using System.IO;
using System.Collections.Generic;

namespace ProductsTests
{
    [TestClass]
    public class ReadWriteJsonTest
    {
        [DataTestMethod]
        [DataRow("Juice",10,6,2, "test.json","{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\", \"$values\":[{\"$type\":\"Products.Food, Products\",\"ProductType\":0,\"Name\":\"Juice\",\"PurchasePrice\":6.0,\"Number\":10,\"MarkUp\":2.0,\"UnitPrice\":8.0,\"AllPrice\":8.0}]}")]
        [DataRow("Cake",120, 15, 5.5, "test.json", "{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\", \"$values\":[{\"$type\":\"Products.Food, Products\",\"ProductType\":0,\"Name\":\"Cake\",\"PurchasePrice\":15.0,\"Number\":120,\"MarkUp\":5.5,\"UnitPrice\":8.0,\"AllPrice\":8.0}]}")]
        [DataRow("Bread", 21, 2.5, 0.6, "test.json", "{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\", \"$values\":[{\"$type\":\"Products.Food, Products\",\"ProductType\":0,\"Name\":\"Bread\",\"PurchasePrice\":2.5,\"Number\":21,\"MarkUp\":0.6,\"UnitPrice\":8.0,\"AllPrice\":8.0}]}")]
        public void ReadFromJson(string value1,int value2,double value3,double value4, string path, string initialString)
        {
            //Arange
            var expected = new Food(value1,value2, value3, value4);
            using (var sw = new StreamWriter(path))
            {
                sw.Write(initialString);
            }
            //Act
            var products = JsonConverter.ReadFromJson(path);
            var result = products[0];
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Hat",23,20, 3.5, "test.json", "{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\",\"$values\":[{\"$type\":\"Products.Clothes, Products\",\"ProductType\":1,\"Name\":\"Hat\",\"PurchasePrice\":20.0,\"Number\":23,\"MarkUp\":3.5,\"UnitPrice\":23.5,\"AllPrice\":540.5}]}")]
        [DataRow("Jacket", 120, 120.5, 2.5, "test.json", "{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\",\"$values\":[{\"$type\":\"Products.Clothes, Products\",\"ProductType\":1,\"Name\":\"Jacket\",\"PurchasePrice\":120.5,\"Number\":120,\"MarkUp\":2.5,\"UnitPrice\":123.0,\"AllPrice\":14760.0}]}")]
        [DataRow("T-shirt", 50, 34.5, 5, "test.json", "{\"$type\":\"System.Collections.Generic.List`1[[Products.Product, Products]], mscorlib\",\"$values\":[{\"$type\":\"Products.Clothes, Products\",\"ProductType\":1,\"Name\":\"T-shirt\",\"PurchasePrice\":34.5,\"Number\":50,\"MarkUp\":5.0,\"UnitPrice\":39.5,\"AllPrice\":1975.0}]}")]
        public void WriteToJson(string value1, int value2, double value3, double value4, string path, string expected)
        {
            //Arange
            var products = new List<Product>() { new Clothes(value1, value2, value3, value4) };
            string result = null;
            //Act
            JsonConverter.WriteToJson(products, path);
            using (var sr = new StreamReader(path))
            {
                result = sr.ReadLine();
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
