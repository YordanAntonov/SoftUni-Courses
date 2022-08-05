using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiPattern = @"(\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\1";//(\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\1
            string digitsPattern = @"(\d)";


            MatchCollection emojiMatches = Regex.Matches(text, emojiPattern);
            MatchCollection digitMatches = Regex.Matches(text, digitsPattern);

            long coolThreshold = 1;

            foreach (Match digit in digitMatches)
            {
                coolThreshold *= int.Parse(digit.Value);
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojiMatches)
            {
                string realEmoji = emoji.Groups["emoji"].Value;
                long emoCoolnes = realEmoji.ToCharArray().Sum(c => c);
                if (emoCoolnes >= coolThreshold)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }
    }
}
