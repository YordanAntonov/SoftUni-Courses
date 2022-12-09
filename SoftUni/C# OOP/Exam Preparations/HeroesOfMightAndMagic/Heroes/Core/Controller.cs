using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IWeapon> weapons;
        private IRepository<IHero> heroes;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            //After Assigning weapon remove it from the repository
            IHero currHero = heroes.FindByName(heroName);
            IWeapon currWeapon = weapons.FindByName(weaponName);

            if (currHero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (currWeapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (currHero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            currHero.AddWeapon(currWeapon);
            weapons.Remove(currWeapon);

            return $"Hero {heroName} can participate in battle using a {currWeapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero currHero = heroes.FindByName(name);
            if (currHero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            string nameType = string.Empty;

            switch (type)
            {
                case nameof(Knight):
                    currHero = new Knight(name, health, armour);
                    nameType = "Sir";
                    break;
                case nameof(Barbarian):
                    currHero = new Barbarian(name, health, armour);
                    nameType = "Barbarian";
                    break;
                default:
                    return null;
            }
            heroes.Add(currHero);

            return $"Successfully added {nameType} {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon currWeapon = weapons.FindByName(name);
            if (currWeapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != nameof(Mace) && type != nameof(Claymore))
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            switch (type)
            {
                case nameof(Claymore):
                    currWeapon = new Claymore(name, durability);
                    break;
                case nameof(Mace):
                    currWeapon = new Mace(name,durability);
                    break;
                default:
                    return null;
            }

            weapons.Add(currWeapon);

            return $"A {currWeapon.GetType().Name.ToLower()} {name} is added to the collection.";

        }

        public string HeroReport()
        {
            ICollection<IHero> orderedHeroes = heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            ICollection<IHero> armedAndAliveHeroes = heroes.Models.Where(h => h.IsAlive).Where(h => h.Weapon != null).ToList();
            IMap map = new Map();

            return map.Fight(armedAndAliveHeroes);
        }
    }
}
