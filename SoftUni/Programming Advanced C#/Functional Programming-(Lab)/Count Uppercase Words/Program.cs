using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isCapitalWord = x => char.IsUpper(x[0]);

            string[] capitalWords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(isCapitalWord).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, capitalWords));
        }
    }
}
