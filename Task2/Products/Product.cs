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
    public abstract class Product
    {
        public Product(string name, int number, double purchasePrice,double markUp)
        {
            Name = name;
            Number = number;
            PurchasePrice = purchasePrice;
            MarkUp = markUp;
        }
        public Product()
        {

        }

        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public int Number { get; set; }
        public abstract ProductTypes ProductType{get;}
        public double MarkUp { get; set; }
        public double UnitPrice { get { return GetUnitPrice(); } }
        public double AllPrice { get { return GetAllPrice(); } }
        protected double GetUnitPrice()
        {
            return PurchasePrice + MarkUp;
        }
        protected double GetAllPrice()
        {
            return (PurchasePrice + MarkUp)*Number;
        }


    }
}
