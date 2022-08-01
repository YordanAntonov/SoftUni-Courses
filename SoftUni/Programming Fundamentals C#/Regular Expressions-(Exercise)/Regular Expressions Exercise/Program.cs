using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<item>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            List<string> list = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    list.Add(match.Groups["item"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        }
    }
}
