using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string incryptedMessage = Console.ReadLine();

            string cmd = "";

            while ((cmd = Console.ReadLine()) != "Reveal")
            {
                string[] instuctions = cmd.Split(new[] { ":|:" }, StringSplitOptions.RemoveEmptyEntries);
                string action = instuctions[0];

                switch (action)
                {
                    case "InsertSpace":
                        int insertIndex = int.Parse(instuctions[1]); //Index is always valid!!!
                        incryptedMessage = incryptedMessage.Insert(insertIndex, " ");
                        break;

                    case "Reverse":
                        string substring = instuctions[1];
                        if (!incryptedMessage.Contains(substring))
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        else
                        {
                            string reversedSubstring = new string(substring.ToCharArray().Reverse().ToArray());
                            int startIdexofSub = incryptedMessage.IndexOf(substring);
                            incryptedMessage = incryptedMessage.Remove(startIdexofSub, substring.Length);
                            incryptedMessage = incryptedMessage.Insert(incryptedMessage.Length, reversedSubstring);
                        }
                        break;
                    case "ChangeAll":
                        string newSubstring = instuctions[1];
                        string replacement = instuctions[2];
                        if (!incryptedMessage.Contains(newSubstring))
                        {
                            continue;
                        }
                        else
                        {
                            incryptedMessage = incryptedMessage.Replace(newSubstring, replacement);
                        }
                        break;
                }

                Console.WriteLine(incryptedMessage);
            }
            Console.WriteLine($"You have a new text message: {incryptedMessage}");
        }
    }
}
