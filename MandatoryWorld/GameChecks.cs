using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MandatoryWorld
{
    public static class GameChecks
    {
        /// <summary>
        /// This method checks if the hero is on the same coordinates as a monster and begins the fight.
        /// </summary>
        /// <param name="hero">The hero that is used</param>
        /// <param name="monsters">The list of monsters for the current game</param>
        public static void MonsterCheck(Hero hero, List<Monster> monsters)
        {
            foreach (var monster in monsters.Where(a => a.Position.PositionY == hero.Position.PositionY && a.Position.PositionX == hero.Position.PositionX))
            {
                Logger.LogInformation(monster.IsDead ? $"Dead {monster.Name}" : $"{hero.Name} has encountered {monster.Name}, fight commenced");

                Fight(hero, monster);
            }
        }

        /// <summary>
        /// This checks if the hero has encountered a chest.
        /// </summary>
        /// <param name="hero">The current hero</param>
        /// <param name="chests">The list of chests for the current game</param>
        public static void ChestCheck(Hero hero, List<Chest>chests)
        {
            if (hero.IsDead) return;
            foreach (var chest in chests.Where(c => c.Position.PositionY == hero.Position.PositionY && c.Position.PositionX == hero.Position.PositionX))
            {
                Logger.LogInformation($"{hero.Name} has encountered {chest.Name}, looting commenced");

                hero.Loot(chest.ContainedLoot());
            }
        }

        /// <summary>
        /// This checks if you have won the game by killing all the monsters.
        /// </summary>
        /// <param name="monsters">The list of monster for the current game</param>
        /// <returns>The gameWon bool, if there are no more monsters left, it is set to true</returns>
        public static bool GameWon(List<Monster> monsters)
        {
            var gameWon = false;
            int monstersAlive = monsters.Count;
            foreach (var monster in monsters.Where(m => m.IsDead == true))
            {
                monstersAlive--;
            }
            if (monstersAlive == 0)
            {
                Logger.LogCritical("There are no more monsters you have won the game");
                gameWon = true;
                Console.ReadKey();
            }
            return gameWon;
        }
        /// <summary>
        /// This method spawns chests and creatures
        /// </summary>
        /// <typeparam name="T">Is the class type like creature or chest</typeparam>
        /// <param name="list">list of the chosen type</param>
        /// <param name="stuff">is the returned object from the inserted factory create method</param>
        public static void Spawn<T>(List<T> list, T stuff)
        {
                list.Add(stuff);
        }

        public static void Fight(Hero hero, Monster monster)
        {
            while (hero.IsDead == false && monster.IsDead == false)
            {
                if (hero.CurrentHitPoints < (hero.HitPoints / 2) && hero.Berserk == false)
                {
                    hero.BerserkMode();
                }
                monster.RecieveHit(hero.Hit());
                hero.RecieveHit(monster.Hit());
            }
        }

        public static void GameStart()
        {
            Logger.LogInformation("press one of the wasd keys to move");
        }
    }
}
