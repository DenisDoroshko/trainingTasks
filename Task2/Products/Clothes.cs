using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Products
{
    /// <summary>
    /// The class representing the type of product clothes
    /// </summary>

    public class Clothes:Product
    {
        /// <summary>
        /// Creates an instance of the Clothes class
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="number">Products number</param>
        /// <param name="purchasePrice">Purchase price</param>
        /// <param name="markUp">Mark up</param>

        public Clothes(string name, int number, double purchasePrice, double markUp) :
            base(name, number, purchasePrice, markUp)
        {

        }

        /// <summary>
        /// Creates an instance of the Clothes class
        /// </summary>

        public Clothes()
        {

        }

        /// <summary>
        /// Private field of product  type
        /// </summary>

        private ProductTypes type = ProductTypes.Clothes;

        /// <summary>
        /// Type of product
        /// </summary>

        public override ProductTypes ProductType { get { return type; } }

        /// <summary>
        /// Overloading the addition operator
        /// </summary>
        /// <param name="firstProduct">First product</param>
        /// <param name="secondProduct">Second product</param>
        /// <returns>Sum of products</returns>

        public static Clothes operator +(Clothes firstProduct, Clothes secondProduct)
        {
            if (firstProduct.Name == secondProduct.Name)
            {
                var resultProduct = new Clothes();
                resultProduct.Name = firstProduct.Name;
                resultProduct.PurchasePrice = (firstProduct.PurchasePrice * firstProduct.Number
                    + secondProduct.PurchasePrice * secondProduct.Number) / (firstProduct.Number + secondProduct.Number);
                resultProduct.MarkUp = (firstProduct.MarkUp * firstProduct.Number
                    + secondProduct.MarkUp * secondProduct.Number) / (firstProduct.Number + secondProduct.Number);
                resultProduct.Number = firstProduct.Number + secondProduct.Number;
                return resultProduct;
            }
            else
            {
                throw new NotEqualNamesException();
            }
        }

        /// <summary>
        /// Overloading the subtraction operator
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="givenNumber">Number</param>
        /// <returns>New instance of the Clothes class with a different quantity value </returns>

        public static Clothes operator -(Clothes product, int givenNumber)
        {
            if (product.Number > givenNumber)
            {
                int newProductsNumber = product.Number - givenNumber;
                return new Clothes(product.Name, newProductsNumber, product.PurchasePrice, product.MarkUp);
            }
            else
            {
                throw new IncorrectNumberException();
            }
        }

        /// <summary>
        /// Overloading a type conversion operation to int type
        /// </summary>
        /// <param name="product">Value of int type</param>

        public static explicit operator int(Clothes product)
        {
            return (int)(product.AllPrice * 100);
        }

        /// <summary>
        /// Overloading a type conversion operation to double type
        /// </summary>
        /// <param name="product">Value of double type</param>

        public static explicit operator double(Clothes product)
        {
            return product.AllPrice;
        }

        /// <summary>
        /// Overloading a type conversion operation from Food to Clothes
        /// </summary>
        /// <param name="product">Instance of Clothes class</param>

       
        public static explicit operator Clothes(Food product)
        {
            return new Clothes(product.Name, product.Number, product.PurchasePrice, product.MarkUp);
        }

        /// <summary>
        /// Overloading a type conversion operation from Furniture to Clothes
        /// </summary>
        /// <param name="product">Instance of Clothes class</param>

        public static explicit operator Clothes(Furniture product)
        {
            return new Clothes(product.Name, product.Number, product.PurchasePrice, product.MarkUp);
        }
        

        /// <summary>
        /// Converts class to string
        /// </summary>
        /// <returns>String representation of a class</returns>

        public override string ToString()
        {
            return $"Type: {ProductType}, Name: {Name}, Number:{Number}, Purchase price:{PurchasePrice}, Mark up:{MarkUp}";
        }

        /// <summary>
        /// Redefining the Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Clothes product = (Clothes)obj;
                return Name == product.Name && Number == product.Number && PurchasePrice == product.PurchasePrice
                    && MarkUp == product.MarkUp;
            }
        }

        /// <summary>
        /// Redefining the GetHashCode method that calculates the hash code of the current object
        /// </summary>
        /// <returns>Hash code of the current object</returns>

        public override int GetHashCode()
        {
            return (int)(Number + PurchasePrice + MarkUp) / 3;
        }
    }
}
