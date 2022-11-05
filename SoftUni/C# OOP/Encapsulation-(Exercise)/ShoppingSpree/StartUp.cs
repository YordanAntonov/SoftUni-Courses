using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personInput = Console.ReadLine().Split(";").ToArray();
            string[] productInput = Console.ReadLine().Split(";").ToArray();


            try
            {

                foreach (var human in personInput)
                {
                    CreatePerson(human, people);
                }

                foreach (var item in productInput)
                {
                    CreateProduct(item, products);
                }

                string inputLine = Console.ReadLine();

                while (inputLine != "END")
                {
                    string[] tokens = inputLine.Split(" ").ToArray();
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person currPerson = people.FirstOrDefault(p => p.Name == personName);
                    Product currProduct = products.FirstOrDefault(p => p.Name == productName);

                    if (currPerson.Money < currProduct.Price)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                        currPerson.AddToBag(currProduct);
                    }

                    inputLine = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.BagOfProducts.Any())
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");

                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        private static void CreateProduct(string item, List<Product> products)
        {
            string[] tokens = item.Split("=").ToArray();
            string name = tokens[0];
            double price = double.Parse(tokens[1]);

            Product product = new Product(name, price);

            products.Add(product);
        }

        private static void CreatePerson(string human, List<Person> people)
        {
            string[] tokens = human.Split("=").ToArray();
            string name = tokens[0];
            double money = double.Parse(tokens[1]);

            Person person = new Person(name, money);

            people.Add(person);
        }
    }
}
