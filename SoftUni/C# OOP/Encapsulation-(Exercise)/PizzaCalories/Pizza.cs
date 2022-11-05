using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string nameOfPizza;

        private List<Topping> toppings;



        public Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough) : this()
        {
            NameOfPizza = name;

            Dough = dough;
        }

        public Dough Dough { get; set; }

        public string NameOfPizza
        {
            get
            {
                return nameOfPizza;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_PIZZA_NAME));
                }

                nameOfPizza = value;
            }
        }


        //public double GetTotalCalories
        //{
        //    get
        //    {
        //        double total = 0;

        //        total += dough.GetDoughCalories();

        //        foreach (var topping in toppings)
        //        {
        //            total += topping.GetToppingCalories();
        //        }

        //        return total;
        //    }
        //}
        public int NumberOfToppings { get => toppings.Count; }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new Exception(string.Format(ExceptionMessages.INVALID_NUMBER_TOPPINGS));
            }
            else
            {
                toppings.Add(topping);
            }
        }

        public double GetTotalPizzaCalories()
        {
            double total = 0;

            total += Dough.GetDoughCalories();

            foreach (var topping in toppings)
            {
                total += topping.GetToppingCalories();
            }


            return total;
        }
    }
}
