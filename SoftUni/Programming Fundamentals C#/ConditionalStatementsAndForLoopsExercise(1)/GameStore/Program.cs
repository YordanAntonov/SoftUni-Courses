using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cardBalance = double.Parse(Console.ReadLine());
            string gameName;
            double gamePrice = 0;
            bool noMoney = false;
            double totalGameSum = 0;
            

            while ((gameName = Console.ReadLine()) != "Game Time")
            {    
                switch (gameName)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;

                        default:
                        Console.WriteLine("Not Found");
                            continue;
                }


                if (cardBalance >= gamePrice)
                {
                    totalGameSum += gamePrice;
                    cardBalance -= gamePrice;
                    Console.WriteLine($"Bought {gameName}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                if (cardBalance <= 0)
                {
                    noMoney = true;
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
            if (noMoney)
            {
                return;
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalGameSum:f2}. Remaining: ${cardBalance:f2}");
            }
        }
    }
}
