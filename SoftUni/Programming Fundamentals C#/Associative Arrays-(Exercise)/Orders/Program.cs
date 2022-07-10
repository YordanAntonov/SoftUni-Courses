using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productInfo = Console.ReadLine().Split().ToArray();
            Dictionary<string, double> productPrice = new Dictionary<string, double>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            while (productInfo[0] != "buy")
            {
                string product = productInfo[0];
                double price = double.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);

                if (!productPrice.ContainsKey(product) && !productQuantity.ContainsKey(product))
                {
                    productPrice[product] = 0.0;
                    productQuantity[product] = 0;
                }
                productPrice[product] = price;
                productQuantity[product] += quantity;

                productInfo = Console.ReadLine().Split();
            }

            foreach (KeyValuePair<string, double> product in productPrice)
            {
                foreach (KeyValuePair<string, int> item in productQuantity)
                {
                    if (product.Key == item.Key)
                    {
                        Console.WriteLine($"{product.Key} -> {(product.Value * item.Value):f2}");
                    }
                }
            }

        }
    }
}
