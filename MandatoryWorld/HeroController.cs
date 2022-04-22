using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    public class HeroController
    {
        /// <summary>
        /// The move method that takes wasd inputs and moves the hero around in the world.
        /// </summary>
        public void move(Hero hero)
        {
            Logger.LogInformation($"{hero.Name} is at {hero.Position.PositionX}, {hero.Position.PositionY}");

            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.W:
                    if (hero.Position.PositionY < World.MaxY)
                    {
                        hero.Position.PositionY += 1;
                    }
                    else
                    {
                        Logger.LogInformation($"{hero.Name} is at the top");
                    }
                    break;
                case ConsoleKey.A:
                    if (hero.Position.PositionX > 1)
                    {
                        hero.Position.PositionX -= 1;
                    }
                    else
                    {
                        Logger.LogInformation($"{hero.Name} can't go further left");
                    }
                    break;
                case ConsoleKey.D:
                    if (hero.Position.PositionX < World.MaxX)
                    {
                        hero.Position.PositionX += 1;
                    }
                    else
                    {
                        Logger.LogInformation($"{hero.Name} can't go further Right");
                    }
                    break;
                case ConsoleKey.S:
                    if (hero.Position.PositionY > 1)
                    {
                        hero.Position.PositionY -= 1;
                    }
                    else
                    {
                        Logger.LogInformation($"{hero.Name} can't go further Down");
                    }
                    break;
                default:
                    Logger.LogInformation($"{hero.Name} is not moving");
                    break;
            }

        }

        /// <summary>
        /// The loot method that takes the loots attributes and adds them to his/her own and checks if the chest was empty.
        /// </summary>
        /// <param name="item">This is the looted item from the chest</param>
        public void Loot(Item item, Hero hero)
        {
            if (item.GetType().Name == "AttackItem")
            {
                AttackItem attackItem = (AttackItem)item;
                hero.AttackPower += attackItem.Damage;
                Logger.LogInformation($"{hero.Name} now have {hero.AttackPower} attack and {hero.Defense} defense");
            }
            else if (item.GetType().Name == "DefenseItem")
            {
                DefenseItem defenseItem = (DefenseItem)item;
                hero.Defense += defenseItem.DamageReduction;
                Logger.LogInformation($"{hero.Name} now have {hero.AttackPower} attack and {hero.Defense} defense");
            }
        }

        /// <summary>
        /// If you are low on hp you go berserk and do damage * 2.
        /// </summary>
        public void BerserkMode(Hero hero)
        {
            hero.Berserk = true;
            hero.AttackPower *= 2;
            Logger.LogInformation($"{hero.Name} are low on health and have gone berserk");
        }
    }
}
