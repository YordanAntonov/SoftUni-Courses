using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textWithProducts = Console.ReadLine();
            const int calPerDay = 2000;
            string pattern = @"(#{1}|\|{1})(?<product>[A-Za-z]+(\s[A-Za-z]+)?)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<cal>\d{1,5})\1";

            MatchCollection matches = Regex.Matches(textWithProducts, pattern);
            int sumOfCalories = 0;
            foreach (Match product in matches)
            {
                int cal = int.Parse(product.Groups["cal"].Value);
                sumOfCalories += cal;
            }
            Console.WriteLine($"You have food to last you for: {sumOfCalories/calPerDay} days!");

            foreach (Match match in matches)
            {
                string product = match.Groups["product"].Value;
                string date = match.Groups["date"].Value;
                string cal = match.Groups["cal"].Value;
                Console.WriteLine($"Item: {product}, Best before: {date}, Nutrition: {cal}");
            }
        }
    }
}
