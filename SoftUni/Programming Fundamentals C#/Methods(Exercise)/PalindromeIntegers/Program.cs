using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            while (num != "END")
            {
                string FindPalindrome = IsItPalindrome(num).ToString().ToLower();
                Console.WriteLine(FindPalindrome);

                num = Console.ReadLine();
            }
        }

        static bool IsItPalindrome(string num)
        {
            string newNum = num;

            string newReversed = new string(num.Reverse().ToArray());
            if (newNum == newReversed)
            {
                return true;
            }
            return false;
        }
    }
}
