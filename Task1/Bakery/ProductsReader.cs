using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Bakery
{
    /// <summary>
    ///The class that provides methods for reading and creating products
    /// </summary>
    
    public static class ProductsReader
    {
        /// <summary>
        /// Creates products
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Produced products</returns>
        
        public static List<BakeryProduct>GetProducts(string path)
        {   
            List<string> data = ReadProducts(path);
            List<BakeryProduct> products = new List<BakeryProduct>();
            foreach(var dataLine in data)
            {
                if (Regex.IsMatch(dataLine, "Bread|Baton|Bun|Pie|Cake"))
                {
                    BakeryProduct newProduct = CreateProduct(dataLine);
                    if(newProduct!=null)
                        products.Add(newProduct);
                }
                else
                {
                    BakeryProduct currentProduct = products.Last();
                    Ingredient ingredient = CreateIngredient(dataLine);
                    if(ingredient!=null)
                        currentProduct.Composition.Add(ingredient);
                }

            }
            return products;
        }

        /// <summary>
        /// Creates product from line
        /// </summary>
        /// <param name="dataLine"></param>
        /// <returns>Bakery product</returns>
        
        private static BakeryProduct CreateProduct(string dataLine)
        {
            string stringType = Regex.Match(dataLine, "Bread|Baton|Bun|Pie|Cake").Value;
            string productName = Regex.Match(dataLine, "\".+\"").Value;
            string stringNumber = Regex.Match(dataLine, "[0-9]+").Value;
            int producedNumber;
            int.TryParse(stringNumber, out producedNumber);
            ProductTypes productType;
            Enum.TryParse(stringType,out productType);
            BakeryProduct product = null;
            switch (productType)
            {
                case ProductTypes.Bread:
                    product = new Bread(productName, producedNumber,new List<Ingredient>());
                    break;
                case ProductTypes.Baton:
                    product = new Baton(productName, producedNumber, new List<Ingredient>());
                    break;
                case ProductTypes.Bun:
                    product = new Bun(productName, producedNumber, new List<Ingredient>());
                    break;
                case ProductTypes.Pie:
                    product = new Bun(productName, producedNumber, new List<Ingredient>());
                    break;
                case ProductTypes.Cake:
                    product = new Bun(productName, producedNumber, new List<Ingredient>());
                    break;
            }
            return product;
        }

        /// <summary>
        /// Creates ingredient from line
        /// </summary>
        /// <param name="dataLine"></param>
        /// <returns>Ingredient of product</returns>
        
        private static Ingredient CreateIngredient(string dataLine)
        {
            string name = Regex.Match(dataLine, @"\D+").Value.Trim();
            MatchCollection values= Regex.Matches(dataLine, @"([0-9]+,[0-9]+|[0-9]+)");
            double weight;
            Console.WriteLine(values[0].Value);
            double.TryParse(values[0].Value, out weight);
            double price;
            double.TryParse(values[1].Value, out price);
            double calories;
            double.TryParse(values[2].Value, out calories);
            Ingredient ingredient = new Ingredient(name,weight,price, calories);
            return ingredient;
        }

        /// <summary>
        /// Reads data from given file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Data</returns>
        
        private static List<string> ReadProducts(string path)
        {
            List<string> data = new List<string>();
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    data.Add(sr.ReadLine());
                }
            }
            return data;
        }
    }
}
