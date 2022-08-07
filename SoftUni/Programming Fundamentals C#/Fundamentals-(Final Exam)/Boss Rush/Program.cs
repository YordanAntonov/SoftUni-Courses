using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boss_Rush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());

            string pattern = @"(\|{1})(?<boss>[A-Z]{4,})\1";
            string titlePattern = @":(#{1})(?<title>[A-Za-z]+(\s{1})[A-Za-z]+)\1";
            Regex regex = new Regex(pattern);
            Regex titleRegex = new Regex(titlePattern);

            Dictionary<string, string> bossesInformation = new Dictionary<string, string>();
            for (int i = 0; i < iterations; i++)
            {
                string bossInfo = Console.ReadLine();
                
                Match match = regex.Match(bossInfo);
                Match titleMatch = titleRegex.Match(bossInfo);

                if (match.Success && titleMatch.Success)
                {
                    string bosName = match.Groups["boss"].Value;
                    string position = titleMatch.Groups["title"].Value;

                    Console.WriteLine($"{bosName}, The {position}");
                    Console.WriteLine($">> Strength: {bosName.Length}");
                    Console.WriteLine($">> Armor: {position.Length}"); 
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
