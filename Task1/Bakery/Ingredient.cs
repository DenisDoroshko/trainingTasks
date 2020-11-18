using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    public class Ingredient
    {
        public Ingredient(string name,double weight,double price,double calorie)
        {
            Name = name;
            Weight = weight;
            Price = price;
            Calorie = calorie;
        }
        public Ingredient()
        {

        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public double Calorie { get; set; }
    }
}
