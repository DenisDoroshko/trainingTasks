using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery;

namespace WorkWithBakery
{
    /// <summary>
    /// The class that provides methods for sorting array of products
    /// </summary>
    
    public static class ArraySorter
    {
        /// <summary>
        /// Sorts array of products by calories
        /// </summary>
        /// <param name="products"></param>
        /// <returns>Sorted array</returns>
        
        public static List<BakeryProduct> SortByCalories(List<BakeryProduct> products)
        {
            List<BakeryProduct> copiedProducts = GetCopy(products);
            for (var i = 0; i < copiedProducts.Count - 1; i++)
            {
                for (var j = 0; j < copiedProducts.Count - 1; j++)
                {
                    if (copiedProducts[j].Calories > copiedProducts[j + 1].Calories)
                    {
                        var tempProduct = copiedProducts[j];
                        copiedProducts[j] = copiedProducts[j + 1];
                        copiedProducts[j + 1] = tempProduct;
                    }
                }
            }
            return copiedProducts;
        }

        /// <summary>
        /// Sorts array of products by price
        /// </summary>
        /// <param name="products"></param>
        /// <returns>Sorted array</returns>
        
        public static List<BakeryProduct> SortByPrice(List<BakeryProduct> products)
        {
            List<BakeryProduct> copiedProducts = GetCopy(products);
            for (var i = 0; i < copiedProducts.Count - 1; i++)
            {
                for (var j = 0; j < copiedProducts.Count - 1; j++)
                {
                    if (copiedProducts[j].Price > copiedProducts[j + 1].Price)
                    {
                        var tempProduct = copiedProducts[j];
                        copiedProducts[j] = copiedProducts[j + 1];
                        copiedProducts[j + 1] = tempProduct;
                    }
                }
            }
            return copiedProducts;
        }

        /// <summary>
        /// Makes copy of products array
        /// </summary>
        /// <param name="products"></param>
        /// <returns>Copy of products array</returns>
        
        private static List<BakeryProduct> GetCopy(List<BakeryProduct> products)
        {
            var copiedProducts = new List<BakeryProduct>(products.Count);
            foreach (var product in products)
            {
                copiedProducts.Add((BakeryProduct)product.Clone());
            }
            return copiedProducts;
        }
    }
}
