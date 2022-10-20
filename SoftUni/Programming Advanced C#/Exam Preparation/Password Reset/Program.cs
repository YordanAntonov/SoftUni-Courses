using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();


            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] tokens = command.Split(' ');
                string action = tokens[0];
                switch (action)
                {
                    case "TakeOdd":
                        string newPass = "";
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                newPass += password[i];
                            }
                        }
                        password = newPass;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];
                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }

    }
}
