using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int treasureWorth = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int bulletCounter = 0;

            while (bulletStack.Count > 0 && locksQueue.Count > 0)
            {
                Shooting(bulletStack, locksQueue, ref bulletCounter, sizeOfBarrel);
            }

            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int reward = treasureWorth - (bulletCounter * bulletPrice);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${reward}");
            }
        }

        static void Shooting(Stack<int> bulletStack, Queue<int>locksQueue, ref int bulletCounter, int sizeOfBarrel)
        {
            int currBullet = bulletStack.Pop();
            bulletCounter++;
            if (currBullet <= locksQueue.Peek())
            {
                Console.WriteLine("Bang!");
                locksQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if (bulletStack.Any() && bulletCounter % sizeOfBarrel == 0)
            {
                Console.WriteLine("Reloading!");
            }
        }
    }
}
