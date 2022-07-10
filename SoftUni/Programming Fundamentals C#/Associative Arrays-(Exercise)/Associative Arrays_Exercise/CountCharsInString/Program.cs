using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine().ToCharArray();
            Dictionary<char, int> charOccurances = new Dictionary<char, int>();
            foreach (char ch in word)
            {
                if (ch != ' ')
                {
                    if (!charOccurances.ContainsKey(ch))
                    {
                        charOccurances.Add(ch, 0);
                    }
                    charOccurances[(char)ch]++;
                }
            }
            foreach (KeyValuePair<char, int> ch in charOccurances)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
