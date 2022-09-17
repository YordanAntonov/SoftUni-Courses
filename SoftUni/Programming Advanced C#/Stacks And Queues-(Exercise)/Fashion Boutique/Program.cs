using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int capacityOfRack = int.Parse(Console.ReadLine());
            int racksNeeded = 1;
            int sumOfClothes = 0;
            

            while (clothesStack.Any())
            {
                if ((sumOfClothes + clothesStack.Peek()) <= capacityOfRack)
                {
                    sumOfClothes += clothesStack.Pop();
                    continue;
                }

                racksNeeded++;
                sumOfClothes = 0;
                sumOfClothes += clothesStack.Pop();

            }
            
            Console.WriteLine(racksNeeded);
        }
    }
}
