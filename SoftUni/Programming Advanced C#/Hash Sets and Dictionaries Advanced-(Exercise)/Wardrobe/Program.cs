using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> clothesCollection = new Dictionary<string,Dictionary<string,int>>();
            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                string[] information = Console.ReadLine().Split(new string[] {" -> ", ","}, StringSplitOptions.RemoveEmptyEntries);
                string color = information[0];

                if (!clothesCollection.ContainsKey(color))
                {
                    clothesCollection[color] = new Dictionary<string,int>();
                }

                for (int j = 1; j < information.Length; j++)
                {
                    string currClothing = information[j];
                    if (!clothesCollection[color].ContainsKey(currClothing))
                    {
                        clothesCollection[color].Add(currClothing, 0);
                    }
                    clothesCollection[color][currClothing]++;
                }
            }

            string[] searchedCloth = Console.ReadLine().Split();
            foreach (var clothing in clothesCollection)
            {
                Console.WriteLine($"{clothing.Key} clothes:");
                foreach (var cloth in clothing.Value)
                {
                    if (clothing.Key == searchedCloth[0] && cloth.Key == (searchedCloth[1]))
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
                
            }
        }
    }
}
