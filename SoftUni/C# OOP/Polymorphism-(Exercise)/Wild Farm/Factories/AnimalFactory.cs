using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] cmdArgs)
        {
            string animalType = cmdArgs[0];
            string animalName = cmdArgs[1];
            double animalWeight = double.Parse(cmdArgs[2]);
            string forthArg = cmdArgs[3];
            IAnimal animal;
            switch (animalType)
            {
                case "Owl":
                    double wingSpan = double.Parse(forthArg);
                    animal = new Owl(animalName, animalWeight, wingSpan);
                    break;

                case "Hen":
                    wingSpan= double.Parse(forthArg);
                    animal = new Hen(animalName, animalWeight, wingSpan);
                    break;

                case "Mouse":
                    string livingRegion = forthArg;
                    animal = new Mouse(animalName, animalWeight, livingRegion);
                    break;

                case "Dog":
                    livingRegion= forthArg;
                    animal = new Dog(animalName, animalWeight, livingRegion);
                    break;

                case "Cat":
                    livingRegion= forthArg;
                    string breed = cmdArgs[4];
                    animal = new Cat(animalName, animalWeight,livingRegion, breed);
                    break;

                case "Tiger":
                    livingRegion = forthArg;
                    breed = cmdArgs[4];
                    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                    break;

                default:
                    throw new InvalidAnimalTypeException();
            }

            return animal;
        }
    }
}
