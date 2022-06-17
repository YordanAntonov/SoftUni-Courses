using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Lab_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gamesList = new List<string>();
            Console.WriteLine("Hello My Friend!");
            Console.WriteLine("Tell me how many favourite games you have??");
            Console.Write("Type here: ");
            int numOfGames = int.Parse(Console.ReadLine());
            Console.WriteLine("Excellent");
            Console.WriteLine("Now tell me the names of the games!");
            for (int i = 0; i < numOfGames; i++)
            {
                gamesList.Add(Console.ReadLine());
            }
            Console.WriteLine("If thats your final entry i will proceed to print them all for you and you can decide if you want to remove and change some of them.");

            Console.WriteLine();
            foreach (string game in gamesList)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine();

            Console.Write("Do you wish to make changes, Yes or No: ");
            string answer = Console.ReadLine();
            bool isMakingChanges = false;
            int changes = 0;
            if (answer == "Yes")
            {
                isMakingChanges = true;
                Console.WriteLine("How many changes you want to make?");
                Console.Write("Type here: ");
                changes = int.Parse(Console.ReadLine());
                Console.WriteLine("Wonderful!");
            }
            else
            {
                Console.WriteLine("Lets continue");
            }

            if (isMakingChanges)
            {
                for (int i = 0; i < changes; i++)
                {
                    Console.Write("Tell me which game you want to change: ");
                    gamesList.Remove(Console.ReadLine());
                    Console.Write("Now tell me which game you want to add: ");
                    string newGame = Console.ReadLine();
                    Console.WriteLine("You want to prioritize this game more, which means you like it more? Tell me position: ");
                    gamesList.Insert(int.Parse(Console.ReadLine()), newGame);
                }
 
                Console.WriteLine("Everything is Completed!");
            }
            Console.WriteLine();
            Console.WriteLine("For the final faze we will ask you if you want to order them alphabetically? Yes or No:");
            if (Console.ReadLine() == "Yes")
            {
                gamesList.Sort();
            }
            else
            {
                Console.WriteLine("Alrighty then!");
            }
            Console.WriteLine("We will now print the complete edition of your list!");
            Console.WriteLine("Enjoy and have a nice day!!!");
            Console.WriteLine();
            foreach (string game in gamesList)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine();
            Console.WriteLine("You can check the database to see if your list contains certain game by typing it below!");
            Console.Write("Type here: ");
            bool isThatGameThere = gamesList.Contains(Console.ReadLine());

            if (isThatGameThere)
            {
                Console.WriteLine("Yes the game is in your Collection!");
            }
            else
            {
                Console.WriteLine("Sadly you dont own this game");
            }
            
        }
    }
}
