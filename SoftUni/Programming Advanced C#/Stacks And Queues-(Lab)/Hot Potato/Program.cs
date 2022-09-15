using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split().ToList());
            int burnToss = int.Parse(Console.ReadLine());
            int tosses = 1;

            while (players.Count > 1)
            {
                for (int i = 0; i < burnToss; i++)
                {
                    if (tosses == burnToss)
                    {
                        Console.WriteLine($"Removed {players.Dequeue()}");
                        tosses = 1;
                    }
                    else
                    {
                        string currName = players.Dequeue();
                        players.Enqueue(currName);
                        tosses++;
                    }
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");

        }
    }
}
