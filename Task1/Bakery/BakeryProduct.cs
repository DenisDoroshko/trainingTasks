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
        private ProductTypes type;
        public ProductTypes Type { get { return type; } }
        public abstract int MarkUp { get; set; }
    }
}
