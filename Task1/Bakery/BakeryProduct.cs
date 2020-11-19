﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithBakery
{
    public enum ProductTypes 
    { 
        Bread,
        Baton,
        Bun,
        Pie,
        Cake
    }

    public abstract class BakeryProduct:ICloneable
    {
        public BakeryProduct(string name,int producedNumber,List<Ingredient> composition)
        {
            Name = name;
            ProducedNumber = producedNumber;
            Composition = composition;
        }
        public BakeryProduct()
        {

        }

        public abstract ProductTypes Type { get; }
        public abstract double MarkUp { get; }
        public List<Ingredient> Composition { get; set; }
        public double Price { get { return GetPrice(); } }
        public double Calories { get { return GetCalories(); } }
        public int ProducedNumber { get; set; }
        public string Name { get; set; }
        private double GetPrice()
        {
            double price = 0;
            foreach(var ingredient in Composition)
            {
                price += ingredient.Price;
            }
            return price + MarkUp;
        }
        private double GetCalories()
        {
            double calories = 0;
            foreach (var ingredient in Composition)
            {
                calories += ingredient.Calories;
            }
            return calories;
        }
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
