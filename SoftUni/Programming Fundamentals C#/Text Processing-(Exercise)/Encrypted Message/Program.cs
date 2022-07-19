using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypted_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string encryptedMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage += (char)(message[i] + 3);
            }
            Console.WriteLine(encryptedMessage);
        }
    }
}
