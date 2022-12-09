using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            HashSet<IHero> knights = players.Where(k => k.GetType().Name == nameof(Knight)).ToHashSet();
            HashSet<IHero> barbarians = players.Where(b => b.GetType().Name == nameof(Barbarian)).ToHashSet();

            while (knights.Any(kh => kh.IsAlive) && barbarians.Any(bh => bh.IsAlive))
            {
                foreach (var knight in knights)
                {
                        foreach (var barb in barbarians)
                        {
                            if (barb.IsAlive && knight.IsAlive)
                            {
                                barb.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                }

                foreach (var barb in barbarians)
                {                                 
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive && barb.IsAlive)
                            {
                                knight.TakeDamage(barb.Weapon.DoDamage());
                            }
                        }
                    
                }
            }

            if (knights.Any(k => k.IsAlive))
            {
                return $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle.";
            }
        }
    }
}
