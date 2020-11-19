using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithBakery
{
    public class Baton : BakeryProduct
    {
        public Baton(string name, int producedNumber, List<Ingredient> composition) : base(name, producedNumber, composition)
        {

        }
        private ProductTypes type = ProductTypes.Baton;
        public override ProductTypes Type { get { return type; } }
        private double markUp = 1;
        public override double MarkUp { get { return markUp; } }
        public override string ToString()
        {
            return $"Type: {type} Name: {Name} Produced Number:{ProducedNumber} Price: {Price} " +
                $"Calories: {Calories}";
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
                return Price == product.Price && Calories == product.Calories;
            }
        }
        public override int GetHashCode()
        {
            return (int)(Price + Calories) / 3;
        }
    }
}
