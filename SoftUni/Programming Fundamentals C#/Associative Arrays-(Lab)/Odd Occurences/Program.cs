using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Occurences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().Select(word => word.ToLower()).ToList();
            Dictionary<string, int> strings = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!strings.ContainsKey(word))
                {
                    strings.Add(word, 0); 
                }
                strings[word]++;
            }
            
            List<string> oddValueWords = strings.Where(word => word.Value % 2 != 0).Select(word => word.Key).ToList();
            Console.WriteLine(string.Join(" ", oddValueWords));
        }
    }
}
