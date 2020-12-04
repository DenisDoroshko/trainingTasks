using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    /// <summary>
    /// Product types
    /// </summary>
    
    public enum ProductTypes
    {
        Food,
        Clothes,
        Furniture
    }

    /// <summary>
    /// The abstract class representing a product
    /// </summary>

    public abstract class Product
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="number">Products number</param>
        /// <param name="purchasePrice">Purchase price</param>
        /// <param name="markUp">Mark up</param>
        
        public Product(string name, int number, double purchasePrice,double markUp)
        {
            Name = name;
            Number = number;
            PurchasePrice = purchasePrice;
            MarkUp = markUp;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        
        public Product()
        {

        }

        /// <summary>
        /// Name of product
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// Purchase price
        /// </summary>
        
        public double PurchasePrice { get; set; }

        /// <summary>
        /// Number of products
        /// </summary>
        
        public int Number { get; set; }

        /// <summary>
        /// Type of product
        /// </summary>
        
        public abstract ProductTypes ProductType{get;}

        /// <summary>
        /// Mark up
        /// </summary>
        
        public double MarkUp { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        
        public double UnitPrice { get { return GetUnitPrice(); } }

        /// <summary>
        /// All price of products
        /// </summary>
        
        public double AllPrice { get { return GetAllPrice(); } }

        /// <summary>
        /// Gets the unit price
        /// </summary>
        /// <returns>The unit price</returns>
        
        protected double GetUnitPrice()
        {
            return PurchasePrice + MarkUp;
        }

        /// <summary>
        /// Gets all price of products
        /// </summary>
        /// <returns>The all price</returns>
        
        protected double GetAllPrice()
        {
            return (PurchasePrice + MarkUp) * Number;
        }


    }
}
