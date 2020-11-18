using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    public enum ProductTypes 
    { 
        Bread,
        Baton,
        Bun,
        Pie,
        Cake
    }

    public abstract class BakeryProduct
    {
        public BakeryProduct(ProductTypes type, double markUp, List<Ingredient> composition)
        {
            this.type = type;
            this.markUp = markUp;
            Composition = composition;
        }
        protected ProductTypes type;
        public ProductTypes Type { get { return type; } }
        protected double markUp;
        public double MarkUp { get {return markUp; } }
        public List<Ingredient> Composition { get; set; }
    }
}
