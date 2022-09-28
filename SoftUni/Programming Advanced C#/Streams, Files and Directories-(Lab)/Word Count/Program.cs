using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            CalculateWordCounts(wordPath, textPath, outputPath);
        }
        public static void CalculateWordCounts(string wordsFilePath, string
       textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] splitArray = new string[]
            {
                " ", ", ", "...", "-", "."
            };

            using StreamReader reader = new StreamReader(wordsFilePath);
            {
                using StreamReader secondReader = new StreamReader(textFilePath);
                {
                    string[] words = reader.ReadToEnd().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    while (!secondReader.EndOfStream)
                    {
                        string[] sentance = secondReader.ReadLine().Split(splitArray, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            foreach (var line in sentance)
                            {
                                if (word.ToLower() == line.ToLower())
                                {
                                    if (!wordCount.ContainsKey(word))
                                    {
                                        wordCount[word] = 0;
                                    }
                                    wordCount[word]++;
                                }
                            }
                        }
                    }

                    using StreamWriter writer = new StreamWriter(outputFilePath);
                    {
                        var sortedWordsCount = wordCount.OrderByDescending(c => c.Value);
                        foreach (var word in sortedWordsCount)
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    } 
                    
                }
            }
        }
    }
}

