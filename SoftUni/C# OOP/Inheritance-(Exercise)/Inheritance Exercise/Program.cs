using System;

namespace Inheritance_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Ivar", 19, "sabre");
            Archer archer = new Archer("Kevin", 24, "long bow");
            Soldier soldier = new Soldier("Andrew", 30);

            Console.WriteLine("***************************************************************************************");
            Console.WriteLine();

            soldier.BattleCry();
            soldier.Atack("orc");
            soldier.Atack("wolf");
            Console.WriteLine(soldier);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine();

            warrior.BattleCry();
            warrior.Atack("orc");
            warrior.Atack("wolf");
            Console.WriteLine(warrior);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine();

            archer.BattleCry();
            archer.Atack("orc");
            archer.Atack("wolf");
            Console.WriteLine(archer);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************************");


        }
    }
}
