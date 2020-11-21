using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery;

namespace WorkWithBakery
{
    public static class SearchInArray
    {
        public static List<BakeryProduct> FindEquals(List<BakeryProduct> products,BakeryProduct givenProduct)
        {
            var equalsProducts = new List<BakeryProduct>();
            foreach (var product in products)
            {
                if (givenProduct.Equals(product))
                    equalsProducts.Add(product);
            }
            return equalsProducts;
        }
        public static List<BakeryProduct> FindByIngredientScope(List<BakeryProduct> products, string givenIngredient, double givenWeight)
        {
            var foundProducts = new List<BakeryProduct>();
            givenIngredient = givenIngredient.ToLower();
            foreach (var product in products)
            {
                Ingredient foundIngredient = product.Composition.Find(x => x.Name.ToLower().Contains(givenIngredient));
                if (foundIngredient != null)
                {
                    if (foundIngredient.Weight > givenWeight)
                    {
                        foundProducts.Add(product);
                    }
                }
            }
            return foundProducts;
        }
        public static List<BakeryProduct> FindByIngredientsNumber(List<BakeryProduct> products, int givenNumber)
        {
            var foundProducts = new List<BakeryProduct>();
            foreach (var product in products)
            {
                if (product.Composition.Count > givenNumber)
                    foundProducts.Add(product);
            }
            return foundProducts;
        }
    }
}
