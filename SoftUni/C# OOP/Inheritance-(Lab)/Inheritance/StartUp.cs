using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            Dog dog = new Dog();

            dog.Eat();
            dog.Bark();

            cat.Eat();
            cat.Meow();
        }
    }
}
