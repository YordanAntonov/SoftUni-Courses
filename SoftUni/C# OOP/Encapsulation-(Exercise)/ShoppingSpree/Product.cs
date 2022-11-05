using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;

        private double price;

        public Product(string name, double price)
        {
            Name = name;

            Price = price;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.EMPTY_NAME_EXCEPTION));
                }

                name = value;
            }
        }
        public double Price
        {
            get { return price; }

            private set
            {
                if (value < 0)
                {
                    throw new Exception(string.Format(ExceptionMessages.NEGATIVE_MONEY_EXCEPTION));
                }

                price = value;
            }
        }

        public override string ToString() => Name;
        
    }
}
