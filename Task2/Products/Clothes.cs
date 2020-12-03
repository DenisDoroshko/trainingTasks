using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Clothes:Product
    {
        public Clothes(string name, int number, double purchasePrice, double markUp) :
            base(name, number, purchasePrice, markUp)
        {

        }

        private ProductTypes type = ProductTypes.Food;

        public override ProductTypes ProductType { get { return type; } }
        public static Clothes operator +(Clothes firstProduct, Food secondProduct)
        {
            if (firstProduct.Name == secondProduct.Name)
            {
            }

            return firstProduct;
        }
    }
}
