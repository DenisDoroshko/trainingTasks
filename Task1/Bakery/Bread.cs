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
    }
}
