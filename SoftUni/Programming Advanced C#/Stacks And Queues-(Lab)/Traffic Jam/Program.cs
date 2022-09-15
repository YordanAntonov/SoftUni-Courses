using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int sumOfCars = 0;

            while (true)
            {
                if (cmd == "end")
                {
                    break;
                }

                if (cmd == "green")
                {
                    if (cars.Count > 0)
                    {
                        for (int i = 0; i < numOfCars; i++)
                        {
                            if (cars.Count == 0)
                            {
                                break;
                            }
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            sumOfCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(cmd);
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{sumOfCars} cars passed the crossroads.");
        }
    }
}
