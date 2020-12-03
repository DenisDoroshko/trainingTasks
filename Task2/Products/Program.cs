using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Product f = new Food("fff", 2, 2,2);
            Product c = new Clothes("fff", 2, 2, 2);
            Product d= (Food)f + (Food)c;
            c = (Food)c;
            Console.WriteLine(c.ProductType);
            Console.ReadLine();
        }
    }
}
