using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songsQueue = new Queue<string>(songs);

            string command = Console.ReadLine();

            while (songsQueue.Any())
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;

                    case "Add":
                        string songName = String.Join(" ", tokens.Skip(1));
                        if (!songsQueue.Contains(songName))
                        {
                            songsQueue.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                            command = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "Show":
                        if (songsQueue.Any())
                        {
                            Console.WriteLine(String.Join(", ", songsQueue));
                        }
                        break;
                }
                command = Console.ReadLine();    
            }

            Console.WriteLine("No more songs!");
        }
    }
}
