﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTheDevisors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            if (number % 10 == 0)
            {
                Console.WriteLine("The number is divisible ny 10");
            }
            else if (number % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (number % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (number % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
                
                



            
        }
    }
}
