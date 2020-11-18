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
        private static BakeryProduct CreateProduct(string dataString)
        {
            string typePattern = "Bread|Baton|Bun";
            string namePattern = "\".+\"";
            string numberPattern = "[0-9]+";
            string stringType = Regex.Match(dataString, typePattern).Value;
            string stringName = Regex.Match(dataString, namePattern).Value;
            string stringNumber = Regex.Match(dataString, numberPattern).Value;
            ProductTypes productType;
            ProductTypes.TryParse(stringType,out productType);
            BakeryProduct product = null;
            switch (productType)
            {
                case ProductTypes.Bread:
                    product = new Bread(new List<Ingredient>());
                    break;
                case ProductTypes.Baton:
                    product = new Bread(new List<Ingredient>());
                    break;
            }
            return product;
        }
        private static Ingredient CreateIngredient(string dataString)
        {
            Ingredient ingredient = null;

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
