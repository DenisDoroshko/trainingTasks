using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnExceptions;

namespace Products
{
    public class Food:Product
    {
        public Food(string name, int number, double purchasePrice,double markUp) :
            base(name, number, purchasePrice,markUp)
        {

        }
        public Food() 
        { 
        }

        private ProductTypes type = ProductTypes.Food;

        public override ProductTypes ProductType { get { return type; } }
        public static Food operator +(Food firstProduct,Food secondProduct)
        {
            if (firstProduct.Name == secondProduct.Name)
            {
                var resultProduct = new Food();
                resultProduct.Name = firstProduct.Name;
                resultProduct.PurchasePrice =(firstProduct. PurchasePrice*firstProduct.Number 
                    + secondProduct.PurchasePrice * secondProduct.Number) / (firstProduct.Number+secondProduct.Number);
                resultProduct.MarkUp= (firstProduct.MarkUp * firstProduct.Number
                    + secondProduct.MarkUp * secondProduct.Number) / (firstProduct.Number + secondProduct.Number);
                resultProduct.Number = firstProduct.Number + secondProduct.Number;
                return resultProduct;
            }
            else
            {
                throw new NotEqualNamesException ();
            }
        }
        public static Food operator -(Food product,int givenNumber)
        { 
            if (product.Number > givenNumber)
            {
                int newProductsNumber = product.Number - givenNumber;
                return new Food(product.Name, newProductsNumber, product.PurchasePrice, product.MarkUp);
            }
            else
            {
                throw new IncorrectNumberException();
            }
        }
        public override string ToString()
        {
            return $"{ProductType} {Name} {Number} {PurchasePrice} {MarkUp}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Food product = (Food)obj; 
                return Name==product.Name&&Number==product.Number&&PurchasePrice==product.PurchasePrice
                    &&MarkUp==product.MarkUp;
            }
        }
        public override int GetHashCode()
        {
            return (int)(Number+PurchasePrice+MarkUp)/3;
        }
    }
}
