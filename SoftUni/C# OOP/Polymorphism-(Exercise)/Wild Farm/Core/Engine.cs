
namespace WildFarm.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Core.Interface;
    using Factories;
    using Factories.Interfaces;
    using IO.Interface;
    using Models.Interfaces;
    using WildFarm.Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ICollection<IAnimal> animals;
        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command = reader.ReadLine();

            while (command != "End")
            {
                this.ProcessInput(command);
                command = reader.ReadLine();
            }

            this.PrintAnimals();
        }

        private IAnimal CreateAnimalUsingFactory(string command)
        {
            string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal currAnimal = this.animalFactory.CreateAnimal(cmdArgs);

            return currAnimal;
        }

        private IFood BuildFoodUsingFactory()
        {
            string[] foodArgs = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            IFood currFood = this.foodFactory.CreateFood(foodType, foodQuantity);

            return currFood;
        }

        private void ProcessInput(string command)
        {
            try
            {
                IAnimal currAnimal = this.CreateAnimalUsingFactory(command);
                IFood currFood = this.BuildFoodUsingFactory();

                this.writer.WriteLine(currAnimal.ProduceSound());

                animals.Add(currAnimal);
                currAnimal.Eat(currFood);


            }
            catch (FoodNotEatenException fne)
            {
                writer.WriteLine(fne.Message);
            }
            catch (InvalidAnimalTypeException iate)
            {
                writer.WriteLine(iate.Message);
            }
            catch (InvalidFoodException iftr)
            {
                writer.WriteLine(iftr.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void PrintAnimals()
        {
            foreach (IAnimal animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
