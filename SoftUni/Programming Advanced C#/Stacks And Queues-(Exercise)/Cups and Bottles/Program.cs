using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();
                if (currBottle >= cups.Peek())
                {
                    wastedWater += currBottle - cups.Dequeue();
                }
                else
                {
                    int currCup = cups.Dequeue();
                    currCup -= currBottle;

                    while (true)
                    {
                        int nextBottle = bottles.Pop();
                        if (currCup > nextBottle)
                        {
                            currCup -= nextBottle;
                        }
                        else
                        {
                            wastedWater += nextBottle - currCup;
                            break;
                        }
                    }
                }

            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }

        }
    }
}
