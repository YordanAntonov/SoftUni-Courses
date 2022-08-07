using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Change":
                        char currChar = char.Parse(tokens[1]);
                        char replacement = char.Parse(tokens[2]);
                        if (text.Contains(currChar))
                        {
                            text = text.Replace(currChar, replacement);
                        }
                        break;

                    case "Includes":
                        {
                            string substring = tokens[1];
                            if (text.Contains(substring))
                            {
                                Console.WriteLine("True");
                                command = Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("False");
                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        break;

                    case "End":
                        {
                            string substring = tokens[1];
                            if (text.EndsWith(substring))
                            {
                                Console.WriteLine("True");
                                command = Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("False");
                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        break;

                    case "Uppercase":
                        text = text.ToUpper();  
                        break;

                    case "FindIndex":
                        char ch = char.Parse(tokens[1]);
                        if (text.Contains(ch))
                        {
                            int charIndex = text.IndexOf(ch);
                            Console.WriteLine(charIndex);
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Cut":
                        int startIndex = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        string cutSubstirng = text.Substring(startIndex, length);
                        text = cutSubstirng;
                        break;

                }

                Console.WriteLine(text);

                command = Console.ReadLine();
            }
        }
    }
}
