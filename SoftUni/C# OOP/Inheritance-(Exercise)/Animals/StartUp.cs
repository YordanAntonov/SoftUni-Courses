using System;
using System.Collections.Generic;
using System.Data;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (command != "Beast!")
            {
                string typeOfAnimal = command;
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string gender = string.Empty;
                if (info.Length > 2)
                {
                    gender = info[2];
                }

                switch (typeOfAnimal)
                {
                    case "Frog":
                        Frog frog = new Frog(info[0], int.Parse(info[1]), gender);
                        if (frog != null) animals.Add(frog);
                        break;

                    case "Dog":
                        Dog dog = new Dog(info[0], int.Parse(info[1]), gender);
                        if (dog != null) animals.Add(dog);
                        break;

                    case "Cat":
                        Cat cat = new Cat(info[0], int.Parse(info[1]), gender);
                        if (cat != null) animals.Add(cat);
                        break;

                    case "Kitten":
                        Kitten kitten = new Kitten(info[0], int.Parse(info[1]));
                        if (kitten != null) animals.Add(kitten);
                        break;

                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(info[0], int.Parse(info[1]));
                        if (tomcat != null) animals.Add(tomcat);
                        break;

                    default:
                        throw new ArgumentException("Invalid Input!");
                }
                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }



    }
}
