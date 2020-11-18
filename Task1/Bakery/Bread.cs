using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    public class Bread:BakeryProduct
    {
        public Bread(List<Ingredient> composition) : base(composition)
        {

        }
        private ProductTypes type=ProductTypes.Bread;
        public override ProductTypes Type { get { return type; } }
        private double markUp=50;
        public override double MarkUp { get { return markUp; } }
        public override string ToString()
        {
            return $"Type: {type} Price: {Price} Calories: {Calories}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else 
            {
                BakeryProduct product = (BakeryProduct)obj;
                return Price != product.Price && Calories != product.Calories;
            }
        }
        public override int GetHashCode()
        {
            return (int)(Price+Calories)/3;
        }
    }
}
