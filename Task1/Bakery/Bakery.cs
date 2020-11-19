using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithBakery
{
    public class Bakery
    {
        public Bakery(List<BakeryProduct> products)
        {
            Products = products;
        }
        public List<BakeryProduct> Products { get; set; }
        public List<BakeryProduct> SortByCalories()
        {
            List<BakeryProduct> copiedProducts=GetCopy();
            for(var i = 0; i < copiedProducts.Count-1; i++)
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
        public List<BakeryProduct> SortByPrice()
        {
            List<BakeryProduct> copiedProducts = GetCopy();
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
        public List<BakeryProduct> FindEquals(BakeryProduct givenProduct)
        {
            var equalsProducts = new List<BakeryProduct>();
            foreach(var product in Products)
            {
                if (givenProduct.Equals(product))
                    equalsProducts.Add(product);
            }
            return equalsProducts;
        }

        private List<BakeryProduct> GetCopy()
        {
            var copiedProducts = new List<BakeryProduct>(Products.Count);
            foreach (var product in Products)
            {
                copiedProducts.Add((BakeryProduct)product.Clone());
            }
            return copiedProducts;
        }
    }
}
