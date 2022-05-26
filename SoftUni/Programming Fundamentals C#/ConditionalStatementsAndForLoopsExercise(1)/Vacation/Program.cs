using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayType = Console.ReadLine();
            double price = 0;

            //Type of day if 
            switch (dayType)
            {
                case "Friday":
                    //Type of groups
                    if (groupType == "Students")
                    {
                        price = groupCount * 8.45;
                        if (groupCount >= 30) //discount 15%
                        {
                            price -= (price * 0.15);
                        }
                    }
                    else if (groupType == "Business")
                    {
                        price = groupCount * 10.90;
                        if (groupCount >= 100) // 10 people go for free
                        {
                            price -= 10 * 10.90;
                        }
                    }
                    else if (groupType == "Regular")
                    {
                        price = groupCount * 15;
                        if (groupCount >= 10 && groupCount <= 20) // total discount 5%
                        {
                            price -= (price * 0.05);
                        }
                    }

                    break;
                case "Saturday":

                    if (groupType == "Students")
                    {
                        price = groupCount * 9.80;
                        if (groupCount >= 30) //discount 15%
                        {
                            price -= (price * 0.15);
                        }
                    }
                    else if (groupType == "Business")
                    {
                        price = groupCount * 15.60;
                        if (groupCount >= 100) // 10 people go for free
                        {
                            price -= 10 * 15.60;
                        }
                    }
                    else if (groupType == "Regular")
                    {
                        price = groupCount * 20;
                        if (groupCount >= 10 && groupCount <= 20) // total discount 5%
                        {
                            price -= (price * 0.05);
                        }
                    }
                    break;
                case "Sunday":

                    if (groupType == "Students")
                    {
                        price = groupCount * 10.46;
                        if (groupCount >= 30) //discount 15%
                        {
                            price -= (price * 0.15);
                        }
                    }
                    else if (groupType == "Business")
                    {
                        price = groupCount * 16;
                        if (groupCount >= 100) // 10 people go for free
                        {
                            price -= 10 * 16;
                        }
                    }
                    else if (groupType == "Regular")
                    {
                        price = groupCount * 22.50;
                        if (groupCount >= 10 && groupCount <= 20) // total discount 5%
                        {
                            price -= (price * 0.05);
                        }
                    }
                    break;         
            }
            Console.WriteLine($"Total price: {price:f2}");







        }
    }
}
