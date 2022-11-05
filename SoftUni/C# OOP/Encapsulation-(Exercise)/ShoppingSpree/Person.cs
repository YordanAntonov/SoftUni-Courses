using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private double money;

        public Person(string name, double money)
        {
            BagOfProducts = new List<Product>();

            Name = name;

            Money = money;
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

        public double Money
        {
            get { return money; }

            private set
            {
                if (value < 0)
                {
                    throw new Exception(string.Format(ExceptionMessages.NEGATIVE_MONEY_EXCEPTION));
                }

                money = value;
            }
        }

        public List<Product> BagOfProducts { get; private set; }

        public void AddToBag(Product product)
        {
            BagOfProducts.Add(product);
            this.Money -= product.Price;
        }
    }
}
