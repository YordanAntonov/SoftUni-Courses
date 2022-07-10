using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = new List<string>();
            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] guestResponse = Console.ReadLine().Split();
                string name = guestResponse[0];
                bool listContainsName = guestList.Contains(name);
                if (guestResponse[2] == "going!")
                {
                    if (listContainsName)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(name);
                    }
                }
                else if (listContainsName && guestResponse[2] == "not")
                {
                    guestList.Remove(name);
                }
                else if (!listContainsName && guestResponse[2] == "not")
                {
                    Console.WriteLine($"{name} is not in the list!");
                }

            }
            foreach(string name in guestList)
            {
                Console.WriteLine(name);
            }
        }

    }
}

