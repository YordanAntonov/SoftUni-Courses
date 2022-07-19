using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsAndNumbers = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (var item in wordsAndNumbers)
            {
                char firstLetter = item[0];
                char lastLetter = item[item.Length -1];

                double number = double.Parse(item.Substring(1, item.Length - 2));
                double result = 0;
                if (char.IsUpper(firstLetter))
                {
                    int firstLetterPositionInAlphabet = firstLetter - 64;
                    result = number / firstLetterPositionInAlphabet;
                }
                else
                {
                    int firstLetterPositionInTheAlphabet = firstLetter - 96;
                    result = number * firstLetterPositionInTheAlphabet;
                }

                if (char.IsUpper(lastLetter))
                {
                    int lastLetterPositionInAlphabet = lastLetter - 64;
                    sum += result - lastLetterPositionInAlphabet;
                }
                else
                {
                    int lastLetterPositionInTheAlphabet = lastLetter - 96;
                    sum += result + lastLetterPositionInTheAlphabet;
                    
                }

            }
            Console.WriteLine($"{sum:f2}");
            

        }
    }
}
