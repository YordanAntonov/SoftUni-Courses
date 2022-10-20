using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string commands = "";

            while ((commands = Console.ReadLine()) != "Generate")
            {
                string[] tokens = commands.Split(new[] { ">>>" }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Contains":
                        string substring = tokens[1];
                        if (!activationKey.Contains(substring))
                        {
                            Console.WriteLine($"Substring not found!");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                            continue;
                        }
                        break;
                    case "Flip":
                        string upperLower = tokens[1];
                        int firstIndex = int.Parse(tokens[2]);
                        int secondIndex = int.Parse(tokens[3]);
                        int subLenght = secondIndex - firstIndex; // 4 - 1 = 3
                        string substringToUperOrLower = activationKey.Substring(firstIndex, subLenght);
                        if (upperLower == "Upper")
                        {
                            activationKey = activationKey.Replace(substringToUperOrLower, substringToUperOrLower.ToUpper());
                        }
                        else
                        {
                            activationKey = activationKey.Replace(substringToUperOrLower, substringToUperOrLower.ToLower());
                        }
                        break;
                    case "Slice":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        int deleteLenght = endIndex - startIndex;
                        activationKey = activationKey.Remove(startIndex, deleteLenght);
                        break;

                }
                Console.WriteLine(activationKey);
            }
            Console.WriteLine($"Your activation key is: {activationKey}");

        }


    }
}
