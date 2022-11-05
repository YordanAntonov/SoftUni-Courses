using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] nameOfPizza = Console.ReadLine().Split(" ").ToArray();
                string[] doughInfo = Console.ReadLine().Split(" ").ToArray();

                string pizzaName = nameOfPizza[1];
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                int grams = int.Parse(doughInfo[3]);

                Dough dough = new Dough(flourType, bakingTechnique, grams);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {

                    string[] toppings = input.Split(" ").ToArray();
                    string toppingType = toppings[1];
                    int toppingGrams = int.Parse(toppings[2]);

                    Topping topping = new Topping(toppingType, toppingGrams);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.GetTotalPizzaCalories():f2} Calories.");
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
    }
}
