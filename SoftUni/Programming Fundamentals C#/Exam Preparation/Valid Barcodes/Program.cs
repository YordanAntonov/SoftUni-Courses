using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valid_Barcodes
{
    internal class Program
    {
        private static object regex;

        static void Main(string[] args)
        {
            string pattern = @"@#+(?<text>[A-Z][a-zA-Z\d]{4,}[A-Z])@#+";
            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                StringBuilder sb = new StringBuilder();
                string barcode = Console.ReadLine();
                Match match = Regex.Match(barcode, pattern);
                bool hasNumbers = true;
                int digitCount = 0;

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                else
                {
                    foreach (char letter in barcode)
                    {
                        if (char.IsDigit(letter))
                        {
                            digitCount++;
                            sb.Append(letter);
                        }
                    }

                    if (digitCount == 0)
                    {
                        hasNumbers = false;
                    }
                }
                if (hasNumbers)
                {
                    Console.WriteLine($"Product group: {sb}");
                }
                else
                {
                    Console.WriteLine($"Product group: 00");
                }
            }
        }
    }
}
