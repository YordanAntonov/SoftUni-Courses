using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rng = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomNumber = rng.Next(words.Length);
                string currentWord = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = currentWord;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
