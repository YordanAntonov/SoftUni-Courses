using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reservation = Console.ReadLine();

            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();

            while (reservation != "PARTY")
            {
                char currReser = reservation[0];

                if (char.IsDigit(currReser))
                {
                    vipGuests.Add(reservation);
                }
                else
                {
                    regulars.Add(reservation);
                }
                reservation = Console.ReadLine();
            }
            string comingGuests = Console.ReadLine();

            while (comingGuests != "END")
            {
                char currReser = comingGuests[0];

                if (char.IsDigit(currReser))
                {
                   vipGuests.Remove(comingGuests);
                }
                else
                {
                    regulars.Remove(comingGuests);
                }
                comingGuests = Console.ReadLine();
            }

            int absentGuests = vipGuests.Count + regulars.Count;
            Console.WriteLine(absentGuests);
            foreach (var reser in vipGuests)
            {
                Console.WriteLine(reser);
            }
            foreach (var reser in regulars)
            {
                Console.WriteLine(reser);
            }
        }
    }
}
