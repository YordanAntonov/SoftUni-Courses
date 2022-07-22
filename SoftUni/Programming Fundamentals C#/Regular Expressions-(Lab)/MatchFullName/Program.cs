using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            Regex regularExpression = new Regex(regex);

            MatchCollection matches = regularExpression.Matches(text);

            Console.WriteLine(String.Join(" ", matches));
        }
    }
}
