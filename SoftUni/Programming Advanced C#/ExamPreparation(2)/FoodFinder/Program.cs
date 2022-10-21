using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace FoodFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            Dictionary<string, HashSet<char>> foodWords = new Dictionary<string, HashSet<char>>()
            {
                {"pear", new HashSet<char>()},
                {"flour", new HashSet<char>()},
                {"pork", new HashSet<char>()},
                {"olive", new HashSet<char>()},
            };

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();

                foreach (var food in foodWords)
                {
                    if (food.Key.Contains(currVowel))
                    {
                        food.Value.Add(currVowel);
                    }

                    if (food.Key.Contains(currConsonant))
                    {
                        food.Value.Add(currConsonant);
                    }
                }

                vowels.Enqueue(currVowel);
            }

            List<string> fittingWords = foodWords.Where(w => w.Key.Count() == w.Value.Count).Select(x => x.Key).ToList();

            Console.WriteLine($"Words found: {fittingWords.Count}");
            foreach (var word in fittingWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
