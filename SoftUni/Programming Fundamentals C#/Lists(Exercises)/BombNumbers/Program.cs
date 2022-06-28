using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> bombNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = bombAndPower[0];
            int power = bombAndPower[1];
            bool sequanceContainsBomb = bombNumbers.Contains(bomb);

            for (int i = 0; i < bombNumbers.Count; i++)
            {

                if (bombNumbers[i] == bomb)
                {
                    int leftRange = i - power;
                    int rightRange = i + power;
                    if (rightRange > bombNumbers.Count - 1)
                    {
                        rightRange = bombNumbers.Count - 1;
                    }
                    if (leftRange < 0)
                    {
                        leftRange = 0;
                    }

                    for (int j = leftRange; j <= rightRange; j++)
                    {
                        bombNumbers[j] = 0;
                    }
                }
            }
            if (sequanceContainsBomb) Console.WriteLine(bombNumbers.Sum());


        }
    }
}
