using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charOccurances = new SortedDictionary<char, int>();
            string word = Console.ReadLine();

            foreach (var ch in word)
            {
                if (!charOccurances.ContainsKey(ch))
                {
                    charOccurances.Add(ch, 0);
                }
                charOccurances[ch]++;
            }

            foreach (var ch in charOccurances)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
