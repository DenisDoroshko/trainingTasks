using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;

namespace WorkWithJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //JsonReader.ReadFromJson();
            var products = new List<Product>();
            products.Add(new Food("Bread", 2, 2, 2));
            products.Add(new Clothes("Trousers", 15, 2, 2));
            products.Add(new Food("Juice", 1, 6, 2));
            products.Add(new Clothes("Hat", 5, 2, 2));
            JsonConverter.WriteToJson(products);
            var result=JsonConverter.ReadFromJson();
            foreach (var item in result)
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }
}
