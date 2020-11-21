using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    /// <summary>
    /// The class representing a bread
    /// </summary>
    
    public class Bread:BakeryProduct
    {

        /// <summary>
        /// Creates an instance of the Bread class
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="producedNumber">Number of products produced</param>
        /// <param name="composition">Product composition</param>

        public Bread(string name, int producedNumber, List<Ingredient> composition) : base(name,producedNumber,composition)
        {

        }

        /// <summary>
        /// Private field of product  type
        /// </summary>

        private ProductTypes type=ProductTypes.Bread;

        /// <summary>
        /// Returns product  type
        /// </summary>

        public override ProductTypes Type { get { return type; } }

        /// <summary>
        /// Private field of product mark up
        /// </summary>

        private double markUp=5;

        /// <summary>
        /// Returns mark up of product
        /// </summary>

        public override double MarkUp { get { return markUp; } }

        /// <summary>
        /// Converts class to string
        /// </summary>
        /// <returns>String representation of a class</returns>

        public override string ToString()
        {
            return $"Type: {type} Name: {Name} Produced Number:{ProducedNumber} Price: {Price} " +
                $"Calories: {Calories}";
        }

        /// <summary>
        /// Redefining the Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>

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

        /// <summary>
        /// Redefining the GetHashCode method that calculates the hash code of the current object
        /// </summary>
        /// <returns>Hash code of the current object</returns>

        public override int GetHashCode()
        {
            return (int)(Price+Calories)/3;
        }
    }
}
