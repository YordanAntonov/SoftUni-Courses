using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAfterThirtyMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int halfHour = 30;

            minutes += halfHour;

            if (minutes >= 60)
            {
                hours++;
                minutes %= 60;
            }
           
            if (hours >= 24)
            {
                hours -= 24;
            }
            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }

        }
    }
}
