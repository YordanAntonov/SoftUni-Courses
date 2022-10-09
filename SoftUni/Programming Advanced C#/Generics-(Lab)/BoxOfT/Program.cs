using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            box.Add(5);
            box.Add(4);
            box.Add(3);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());



        }
    }
}
