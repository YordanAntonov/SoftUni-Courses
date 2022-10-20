using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(@{1}|#{1})(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            List<string> wordsPairs = new List<string>();

            MatchCollection matches = Regex.Matches(text, pattern);
            if (matches.Count <= 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match word in matches)
            {
                string firstWord = word.Groups["word1"].Value;
                string secondWord = word.Groups["word2"].Value;
                string reversedWord = new string(secondWord.ToCharArray().Reverse().ToArray());
                if (firstWord == reversedWord)
                {
                    mirrorWords[firstWord] = secondWord;
                }
            }
            if (mirrorWords.Count <= 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                foreach (var wordPair in mirrorWords)
                {
                    string concatWords = ($"{wordPair.Key} <=> {wordPair.Value}");
                    wordsPairs.Add(concatWords);
                }

                Console.WriteLine(string.Join(", ", wordsPairs));
            }



        }
    }
}
