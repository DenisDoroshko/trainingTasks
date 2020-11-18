using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Bakery
{
    public class ProductsReader
    {
        public static List<BakeryProduct>GetProducts()
        {   
            List<string> data = ReadProducts();
            List<BakeryProduct> products = new List<BakeryProduct>();
            string typePattern = "Bread|Baton|Bun";
            foreach(var dataLine in data)
            {
                if (Regex.IsMatch(dataLine, typePattern))
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
            
            return null;
        }
        private static BakeryProduct CreateProduct(string dataLine)
        {
            string typePattern = "Bread|Baton|Bun";
            string namePattern = "\".+\"";
            string numberPattern = "[0-9]+";
            string stringType = Regex.Match(dataLine, typePattern).Value;
            string productName = Regex.Match(dataLine, namePattern).Value;
            string stringNumber = Regex.Match(dataLine, numberPattern).Value;
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
                    product = new Bread(productName, producedNumber, new List<Ingredient>());
                    break;
            }
            return product;
        }
        private static Ingredient CreateIngredient(string dataLine)
        {
            string name = Regex.Match(dataLine, @"\D+").Value;
            MatchCollection values= Regex.Matches(dataLine, @"([0-9]+\.[0-9]+|[0-9]+)");
            double weight;
            double.TryParse(values[0].Value, out weight);
            double price;
            double.TryParse(values[0].Value, out price);
            double calories;
            double.TryParse(values[0].Value, out calories);
            Ingredient ingredient = new Ingredient(name,weight,price, calories);
            return ingredient;
        }
        private static List<string> ReadProducts()
        {
            List<string> data = new List<string>();
            using (var sr = new StreamReader("products.txt"))
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
