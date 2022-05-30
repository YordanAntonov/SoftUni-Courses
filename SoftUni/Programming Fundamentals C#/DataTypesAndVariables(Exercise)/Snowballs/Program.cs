using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger SnowBallMaxValue = int.MinValue;
            BigInteger snowballValue = 0;
            BigInteger snowballSnow = 0;
            BigInteger snowballTime = 0;
            int snowballQuality = 0;
            string snowballFormula = "";


            for (int i = 1; i <= snowballs; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                BigInteger currSnowballValue = (snowballSnow / snowballTime);
                snowballValue = BigInteger.Pow(currSnowballValue, snowballQuality);
                if (snowballValue > SnowBallMaxValue)
                {
                    SnowBallMaxValue = snowballValue;
                    snowballFormula = ($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
                }

            }
            Console.WriteLine(snowballFormula);

            
        }
    }
}
