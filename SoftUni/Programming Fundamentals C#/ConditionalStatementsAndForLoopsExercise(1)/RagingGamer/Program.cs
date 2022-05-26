using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagingGamer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int losses = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int hsB = 0;
            int mB = 0;
            int kbB = 0;
            int dpB = 0;
            

            for (int i = 1; i <= losses; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    hsB++;
                    mB++;
                    kbB++;
                    if (kbB % 2 == 0)
                    {
                        dpB++;
                    }
                }
                else if (i % 2 == 0)
                {
                    hsB++;
                }
                else if (i % 3 == 0)
                {
                    mB++;
                }
            }
            double totalDmg = (hsB * headsetPrice) + (mB * mousePrice) + (kbB * keyboardPrice) + (dpB * displayPrice);
            Console.WriteLine($"Rage expenses: {totalDmg:f2} lv.");




        }
    }
}
