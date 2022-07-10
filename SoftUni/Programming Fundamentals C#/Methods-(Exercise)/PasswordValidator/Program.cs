using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool IsLongEnough = IsItInLenght(password);
            bool IsIncludingDigitsAndLetters = IsItOnlyLettersAndDigits(password);
            bool IsIncludingTwoDigits = AtleastTwoDigits(password);

            if (!IsLongEnough)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!IsIncludingDigitsAndLetters)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!IsIncludingTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (IsLongEnough && IsIncludingDigitsAndLetters && IsIncludingTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }

        }

        private static bool IsItInLenght(string password)
        {
            return password.Length >= 6 && password.Length <= 10;   
        }
        private static bool IsItOnlyLettersAndDigits(string password)
        {
            foreach ( char letter in password)
            {
                if (!char.IsLetterOrDigit(letter))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool AtleastTwoDigits(string password)
        {
            int counter = 0;
            foreach (char letter in password)
            {
                if (char.IsDigit(letter))
                {
                    counter++;
                }
            }
            return counter >= 2;
        }

    }
}
