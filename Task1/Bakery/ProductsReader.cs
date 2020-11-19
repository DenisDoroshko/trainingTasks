﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WorkWithBakery
{
    public class ProductsReader
    {
        public static List<BakeryProduct>GetProducts()
        {   
            List<string> data = ReadProducts();
            List<BakeryProduct> products = new List<BakeryProduct>();
            foreach(var dataLine in data)
            {
                if (Regex.IsMatch(dataLine, "Bread|Baton|Bun"))
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
        private static BakeryProduct CreateProduct(string dataLine)
        {
            string stringType = Regex.Match(dataLine, "Bread|Baton|Bun").Value;
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
            }
            return product;
        }
        private static Ingredient CreateIngredient(string dataLine)
        {
            string name = Regex.Match(dataLine, @"\D+").Value.Trim();
            MatchCollection values= Regex.Matches(dataLine, @"([0-9]+\.[0-9]+|[0-9]+)");
            double weight;
            double.TryParse(values[0].Value, out weight);
            double price;
            double.TryParse(values[1].Value, out price);
            double calories;
            double.TryParse(values[2].Value, out calories);
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
