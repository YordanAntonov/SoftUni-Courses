using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo[continent] = new Dictionary<string, List<string>>();
                }

                if (!continentsInfo[continent].ContainsKey(country))
                {
                    continentsInfo[continent][country] = new List<string>();
                }

                continentsInfo[continent][country].Add(city);
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.Write(string.Join(", ", country.Value));
                    Console.WriteLine();
                    //foreach (var city in country.Value)
                    //{
                    //    Console.Write($"");
                    //}
                }
            }
        }
    }
}
