using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+.?[\d]+?)\$";
            Regex regex = new Regex(pattern);

            string command = "";
            double sum = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match currMatch = regex.Match(command);

                if (currMatch.Success)
                {
                    string customer = currMatch.Groups["customer"].Value;
                    string product = currMatch.Groups["product"].Value;
                    int count = int.Parse(currMatch.Groups["count"].Value);
                    double price = double.Parse(currMatch.Groups["price"].Value);
                    double totalPrice = count * price;
                    sum += totalPrice;
                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}
