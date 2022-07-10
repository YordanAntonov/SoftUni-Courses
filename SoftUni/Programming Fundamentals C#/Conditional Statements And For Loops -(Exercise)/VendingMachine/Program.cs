using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coins;
            double moneySum = 0;
            string product;
            double productPrice = 0;

            while ((coins = Console.ReadLine()) != "Start")
            {
                double inputCoins = double.Parse(coins);
                if(inputCoins == 0.1 || inputCoins == 0.2 || inputCoins == 0.5 || inputCoins == 1 || inputCoins == 2)
                {
                    moneySum += inputCoins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputCoins}");
                }
            }
            while ((product = Console.ReadLine()) != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        continue;                    
                }
                if(productPrice <= moneySum)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    moneySum -= productPrice;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            }
            Console.WriteLine($"Change: {moneySum:f2}");

            



        }
    }
}
