using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits__Letters_and_Others
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentance = Console.ReadLine();
            char[] numbers = sentance.Where(ch => char.IsNumber(ch)).ToArray();
            char[] letters = sentance.Where(ch => char.IsLetter(ch)).ToArray();
            char[] others = sentance.Where(ch => !char.IsLetterOrDigit(ch)).ToArray();

            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
