using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {


            int[] arr = ArrayCreator.Create(10, 20);
            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
