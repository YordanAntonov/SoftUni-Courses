using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string decryptedMessage = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] tokens = command.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Move":
                        int numOfLetters = int.Parse(tokens[1]);
                        string substringToMove = decryptedMessage.Substring(0, numOfLetters);
                        decryptedMessage = decryptedMessage.Remove(0, numOfLetters);
                        decryptedMessage = decryptedMessage.Insert(decryptedMessage.Length, substringToMove);
                        break;

                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        string value = tokens[2];
                        if (index >= 0 && index <= decryptedMessage.Length)
                        {
                            decryptedMessage = decryptedMessage.Insert(index, value);
                        }
                        break;

                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];
                        if (decryptedMessage.Contains(substring))
                        {
                            decryptedMessage = decryptedMessage.Replace(substring, replacement);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {decryptedMessage}");
        }
    }
}
