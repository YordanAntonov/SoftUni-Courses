namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;
               
                string line = string.Empty;
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        string replacedSymbols = ReplacedSymbols(line);
                        string reversedSentance = ReverseWords(replacedSymbols);
                        sb.AppendLine(reversedSentance);
                    }
                    counter++;
                }
                return sb.ToString().TrimEnd();
            }
        }

        private static string ReplacedSymbols(string line)
        {
            string[] symbolsToReplace = { "-", ",", ".", "!", "?" };
            foreach (var symbol in symbolsToReplace)
            {
                line = line.Replace(symbol, "@");
            }
            return line;
        }
        private static string ReverseWords(string replacedSymbols)
        {
            string[] reverse = replacedSymbols.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            return string.Join(" ", reverse);
        }

    }
}
