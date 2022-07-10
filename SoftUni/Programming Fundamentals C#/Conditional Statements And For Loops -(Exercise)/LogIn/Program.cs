using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = reverseStringConvert(username);
            string login;
            int falseAttempt = 0;
            bool isBlocked = false;
            
            while ((login = Console.ReadLine()) != password)
            {
                falseAttempt++; 
                if (falseAttempt == 4)
                {
                    isBlocked = true;
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                              
            }

            if (isBlocked)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
            }
            
            
        }

        private static string reverseStringConvert(string username)
        {
            string r = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                r += username[i];
            }

            return r;
        }
    }
}
