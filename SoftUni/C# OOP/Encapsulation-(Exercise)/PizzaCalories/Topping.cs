using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BASE_CAL_PER_GRAM = 2;
        private const int MIN_TOPPING_GRAM = 1;
        private const int MAX_TOPPING_GRAM = 50;


        private string toppingType;

        private int toppingGrams;

        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 },
        };


        public Topping(string toppingType, int toppingGrams)
        {
            ToppingType = toppingType;

            ToppingGrams = toppingGrams;
        }


        public string ToppingType
        {
            get { return toppingType; }

            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "meat" && lowerValue != "veggies" && lowerValue != "cheese" && lowerValue != "sauce")
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_INGRIDIENT, value));
                }

                toppingType = value;
            }
        }


        public int ToppingGrams
        {
            get { return toppingGrams; }

            private set
            {
                if (value < MIN_TOPPING_GRAM || value > MAX_TOPPING_GRAM)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_WEIGHT, ToppingType));
                }

                toppingGrams = value;
            }
        }


        public double GetToppingCalories()
        {
            double result = (BASE_CAL_PER_GRAM * modifiers[ToppingType.ToLower()]) * ToppingGrams;

            return result;
        }
    }
}
