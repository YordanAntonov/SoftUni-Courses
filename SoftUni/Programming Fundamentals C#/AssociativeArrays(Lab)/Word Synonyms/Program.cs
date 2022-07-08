using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfEntries = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> wordSynonims = new Dictionary<string, List<string>>();

            for (int i = 0; i < numOfEntries; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordSynonims.ContainsKey(word))
                {
                    wordSynonims[word] = new List<string>();
                }

                wordSynonims[word].Add(synonym);
            }

            foreach (KeyValuePair<string, List<string>> word in wordSynonims)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
