    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CrossRoads
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int green = int.Parse(Console.ReadLine());
                int free = int.Parse(Console.ReadLine());
         
                int counter = 0;
                Queue<string> cars = new Queue<string>();

                string command = Console.ReadLine();

                while (command != "END")
                {
                    int greenLight = green;
                    int freeWindow = free;
                    if (command == "green")//The widnows starts
                    {
                        if (cars.Any())
                        {
                            int countOfCars = cars.Count;
                            for (int i = 0; i < countOfCars; i++)
                            {
                                string currCar = cars.Peek();
                                if (greenLight > 0)
                                {
                                    if (currCar.Length <= greenLight)
                                    {
                                        greenLight -= currCar.Length;
                                        cars.Dequeue();
                                        counter++;
                                    }
                                    else //green left with 2sec; free window is 5 sec
                                    {
                                        int leftOverTime = greenLight + freeWindow;
                                        if (currCar.Length <= leftOverTime)
                                        {
                                            greenLight -= currCar.Length;
                                            cars.Dequeue();
                                            counter++;
                                        }
                                        else //Crash
                                        {
                                        
                                            int hitPoint = (currCar.Length + leftOverTime) - currCar.Length;
                                            Console.WriteLine("A crash happened!");
                                            Console.WriteLine($"{currCar} was hit at {currCar[hitPoint]}.");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            
                            
                            }
                        }
                    }
                    else
                    {
                        cars.Enqueue(command);
                    }

                    command = Console.ReadLine();
                }

                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
        }
    }
