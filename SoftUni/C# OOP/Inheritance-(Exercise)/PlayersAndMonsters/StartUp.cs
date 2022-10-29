using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero hero = new SoulMaster("Ivan", 168);
            Console.WriteLine(hero);
            Hero hero2 = new DarkKnight("Kolag", 210);

            Hero[] heroes = new Hero[] {hero, hero2};

            foreach (var item in heroes)
            {
                Console.WriteLine();
            }
        }
    }
}
