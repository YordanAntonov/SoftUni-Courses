using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Of_Code_and_Logic_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            Dictionary<string, KeyValuePair<int, int>> heroes = new Dictionary<string, KeyValuePair<int, int>>();
            List<string> heroRecord = new List<string>();

            for (int i = 0; i < iterations; i++)
            {
                string[] heroDetails = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroDetails[0];
                int hitPoints = int.Parse(heroDetails[1]);
                int manaPoints = int.Parse(heroDetails[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes[heroName] = new KeyValuePair<int, int>(hitPoints, manaPoints);
                    heroRecord.Add(heroName);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string heroName = tokens[1];

                KeyValuePair<int, int> currHeroInfo = heroes[heroName];
                int hitPoints = currHeroInfo.Key;
                int currMana = currHeroInfo.Value;

                switch (action)
                {
                    case "CastSpell":
                        int manaNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (currMana >= manaNeeded)
                        {
                            int manaLeft = currMana - manaNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {manaLeft} MP!");
                            heroes[heroName] = new KeyValuePair<int, int>(hitPoints, manaLeft);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string atacker = tokens[3];
                        if (hitPoints > 0)
                        {
                            int newHitPoints = hitPoints - damage;
                            if (newHitPoints > 0)
                            {
                                Console.WriteLine($"{heroName} was hit for {damage} HP by {atacker} and now has {newHitPoints} HP left!");
                                heroes[heroName] = new KeyValuePair<int, int>(newHitPoints, currMana);
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} has been killed by {atacker}!");
                                heroes.Remove(heroName);
                                heroRecord.Remove(heroName);
                            }
                        }
                        break;

                    case "Recharge":
                        {
                            int amount = int.Parse(tokens[2]);
                            int newAmountOfMana = currMana + amount;
                            if (currMana < 200)
                            {
                                if (newAmountOfMana > 200)
                                {
                                    newAmountOfMana = 200;
                                }
                                int rechargedMana = newAmountOfMana - currMana;

                                Console.WriteLine($"{heroName} recharged for {rechargedMana} MP!");
                                heroes[heroName] = new KeyValuePair<int, int>(hitPoints, newAmountOfMana);
                            }
                        }
                        break;

                    case "Heal":
                        {
                            int amount = int.Parse(tokens[2]);
                            int newAmountOfHitPoints = hitPoints + amount;
                            if (hitPoints <= 100)
                            {
                                if (newAmountOfHitPoints > 100)
                                {
                                    newAmountOfHitPoints = 100;
                                }
                                int rechargedHealth = newAmountOfHitPoints - hitPoints;

                                Console.WriteLine($"{heroName} healed for {rechargedHealth} HP!");
                                heroes[heroName] = new KeyValuePair<int, int>(newAmountOfHitPoints, currMana);
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (string hero in heroRecord)
            {
                Console.WriteLine(hero);
                Console.WriteLine($"  HP: {heroes[hero].Key}");
                Console.WriteLine($"  MP: {heroes[hero].Value}");
            }
        }
    }
}
