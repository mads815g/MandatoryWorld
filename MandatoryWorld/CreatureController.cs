using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld
{
    public class CreatureController
    {
        /// <summary>
        /// This is the hit method that decides the dmg of your hit.
        /// </summary>
        /// <returns></returns>
        public int Hit(Creature creature)
        {
            Random rng = new Random();
            int damage = rng.Next(creature.AttackPower);
            return damage;
        }

        /// <summary>
        /// This is the damage taken method the how much of the damagetaken that goes through.
        /// </summary>
        /// <param name="damageTaken">Original damage from hit</param>
        public void RecieveHit(int damageTaken, Creature creature)
        {
            if (damageTaken <= creature.Defense)
            {
                creature.CurrentHitPoints -= 0;
            }
            else
            {
                creature.CurrentHitPoints -= (damageTaken - creature.Defense);
                if (creature.CurrentHitPoints < 0)
                {
                    creature.CurrentHitPoints = 0;
                }
            }
            Logger.LogInformation($"{creature.Name} has {creature.CurrentHitPoints} HP left");

            if (creature.CurrentHitPoints <= 0)
            {
                creature.IsDead = true;
                creature.Notify();
            }
        }

        /// <summary>
        /// This method checks if you are dead and have lost the game.
        /// </summary>
        public void GameOver(Creature creature)
        {
            if (creature.IsDead)
            {
                Logger.LogCritical($"{creature.Name} have died, Game Over");
                Console.ReadKey();
            }
        }
    }
}
