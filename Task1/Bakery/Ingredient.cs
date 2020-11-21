using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    /// <summary>
    /// The class representing an ingredient
    /// </summary>
    
    public class Ingredient:ICloneable
    {
        /// <summary>
        /// Creates an instance of the Ingredient class
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <param name="weight">Weight of ingredient</param>
        /// <param name="price">Price of ingredient</param>
        /// <param name="calories">Calories of ingredient</param>
        
        public Ingredient(string name,double weight,double price,double calories)
        {
            Name = name;
            Weight = weight;
            Price = price;
            Calories = calories;
        }

        /// <summary>
        /// Creates an instance of the Ingredient class
        /// </summary>
        
        public Ingredient()
        {

        }

        /// <summary>
        /// Ingredient name
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// Ingredient weight
        /// </summary>
        
        public double Weight { get; set; }

        /// <summary>
        /// Ingredient price
        /// </summary>
        
        public double Price { get; set; }

        /// <summary>
        /// Ingredient calories
        /// </summary>
        
        public double Calories { get; set; }

        /// <summary>
        /// Copies the class
        /// </summary>
        /// <returns>Copy of class</returns>

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
