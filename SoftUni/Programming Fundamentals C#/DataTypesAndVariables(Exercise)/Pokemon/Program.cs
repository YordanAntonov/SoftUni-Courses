using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceBtwTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            double halpOfPower = (double)pokePower - (pokePower * 0.50);
            int pokedTargets = 0;

            while (pokePower >= distanceBtwTargets)
            {
                
                pokePower -= distanceBtwTargets;    
                pokedTargets++;
                
                if (pokePower == halpOfPower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);              
        }
    }
}
