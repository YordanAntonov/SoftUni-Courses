using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            List<string> validUsers = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                bool isValid = true;
                if (usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    foreach (var letter in usernames[i])
                    {
                        if (!(char.IsLetterOrDigit(letter) || letter == '-' || letter == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validUsers.Add(usernames[i]);
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, validUsers));

        }
    }
}
