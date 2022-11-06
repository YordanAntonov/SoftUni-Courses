
namespace Telephony
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {


            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stationaryphone stationaryPhone = new Stationaryphone();
            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {

                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }


        }
    }
}
