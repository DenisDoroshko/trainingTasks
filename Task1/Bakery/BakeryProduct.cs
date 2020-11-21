using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    /// <summary>
    /// Bakery product types
    /// </summary>
    
    public enum ProductTypes 
    { 
        Bread,
        Baton,
        Bun,
        Pie,
        Cake
    }

    /// <summary>
    /// The abstract class representing a product of bakery
    /// </summary>
    
    public abstract class BakeryProduct:ICloneable
    {

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="producedNumber">Number of products produced</param>
        /// <param name="composition">Product composition</param>
        
        public BakeryProduct(string name,int producedNumber,List<Ingredient> composition)
        {
            Name = name;
            ProducedNumber = producedNumber;
            Composition = composition;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        
        public BakeryProduct()
        {

        }

        /// <summary>
        /// Product type
        /// </summary>
        
        public abstract ProductTypes Type { get; }

        /// <summary>
        /// Mark up
        /// </summary>
        
        public abstract double MarkUp { get; }

        /// <summary>
        /// Product composition
        /// </summary>
        
        public List<Ingredient> Composition { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        
        public double Price { get { return GetPrice(); } }

        /// <summary>
        /// Calories
        /// </summary>
        
        public double Calories { get { return GetCalories(); } }

        /// <summary>
        /// Number of products produced
        /// </summary>
        
        public int ProducedNumber { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// Gets the sum of prices from all ingredients with mark up
        /// </summary>
        /// <returns>Price of product</returns>

        private double GetPrice()
        {
            double price = 0;
            foreach(var ingredient in Composition)
            {
                price += ingredient.Price;
            }
            return price + MarkUp;
        }

        /// <summary>
        /// Gets the sum of calories from all ingredients
        /// </summary>
        /// <returns>Sum of calories</returns>
        
        private double GetCalories()
        {
            double calories = 0;
            foreach (var ingredient in Composition)
            {
                calories += ingredient.Calories;
            }
            return calories;
        }

        /// <summary>
        /// Copies the class
        /// </summary>
        /// <returns>Copy of class</returns>
        
        public object Clone()
        {
            var copiedProduct = (BakeryProduct)this.MemberwiseClone();
            var copiedIngredients = new List<Ingredient>(Composition.Count);
            foreach(var ingredient in Composition)
            {
                copiedIngredients.Add((Ingredient)ingredient.Clone());
            }
            copiedProduct.Composition = copiedIngredients;
            return copiedProduct;
        }
    }
}
