using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequance = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            int number;
            int index;

            while (sequance.Count != 0)
            {
                index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    number = sequance[0];
                    sequance[0] = sequance[sequance.Count - 1];
                }
                else if (index > sequance.Count - 1)
                {
                    number = sequance[sequance.Count - 1];
                    sequance[sequance.Count - 1] = sequance[0];
                }
                else
                {
                    number = sequance[index];
                    sequance.RemoveAt(index);
                }

                sum += number;

                for (int i = 0; i < sequance.Count; i++)
                {
                    if (sequance[i] <= number)
                    {
                        sequance[i] += number;
                    }
                    else
                    {
                        sequance[i] -= number;
                    }
                }
            }
            Console.WriteLine($"{sum}");

        }
    }
}
