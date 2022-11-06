using Border_Control.Models;
using Border_Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Border_Control
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Citizen> citizens = new HashSet<Citizen>();
            HashSet<Rebel> rebels = new HashSet<Rebel>();
            

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ").ToArray();

                if (personInfo.Length == 4)
                {
                    Citizen buyer = new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]);
                    citizens.Add(buyer);
                }
                else
                {
                    Rebel buyer = new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                    rebels.Add(buyer);
                }
            }

            string command = Console.ReadLine();
            int totalFood = 0;
            while (command != "End")
            {
                if (citizens.Any(n => n.NameOrModel == command))
                {
                    Citizen currCitizen = citizens.FirstOrDefault(c => c.NameOrModel == command);

                    totalFood += currCitizen.BuyFood();
                }
                else
                {
                    if (rebels.Any(n => n.Name == command))
                    {
                        Rebel currRebel = rebels.FirstOrDefault(c => c.Name == command);
                        
                        totalFood += currRebel.BuyFood();
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(totalFood);
        }
    }
}
