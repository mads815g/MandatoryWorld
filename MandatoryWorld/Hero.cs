using System;

namespace MandatoryWorld
{
    /// <summary>
    /// The hero class, which inherits from Creature.
    /// </summary>
    public class Hero : Creature
    {
        public bool Berserk { get; set; }
        /// <summary>
        /// The hero class constructor. The hero always starts at 1,1 in the world.
        /// </summary>
        /// <param name="name">The name of the hero</param>
        /// <param name="hitPoints">The health points of the hero</param>
        /// <param name="attackPower">The attack power of the hero</param>
        public Hero(string name, int hitPoints, int attackPower) : base(name)
        {
            PositionX = 1;
            PositionY = 1;
            HitPoints = hitPoints;
            CurrentHitPoints = HitPoints;
            AttackPower = attackPower;
            Berserk = false;
        }

        /// <summary>
        /// The move method that takes wasd inputs and moves the hero around in the world.
        /// </summary>
        public void move()
        {
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.W:
                    if (PositionY < World.MaxY)
                    {
                        PositionY += 1;
                    }
                    else
                    {
                        Console.WriteLine("You are at the top");
                    }
                    break;
                case ConsoleKey.A:
                    if (PositionX > 1)
                    {
                        PositionX -= 1;
                    }
                    else
                    {
                        Console.WriteLine("You can't go further left");
                    }
                    break;
                case ConsoleKey.D:
                    if (PositionX < World.MaxX)
                    {
                        PositionX += 1;
                    }
                    else
                    {
                        Console.WriteLine("You can't go further Right");
                    }
                    break;
                case ConsoleKey.S:
                    if (PositionY > 1)
                    {
                        PositionY -= 1;
                    }
                    else
                    {
                        Console.WriteLine("You can't go further Down");
                    }
                    break;
                default:
                    Console.WriteLine("You are not moving");
                    break;
            }

        }

        /// <summary>
        /// The loot method that takes the loots attributes and adds them to his/her own and checks if the chest was empty.
        /// </summary>
        /// <param name="item">This is the looted item from the chest</param>
        public void Loot(Item item)
        {
            if (item.GetType().Name == "AttackItem")
            {
                AttackItem attackItem = (AttackItem)item;
                AttackPower += attackItem.Damage;
            } 
            else if (item.GetType().Name == "DefenseItem")
            {
                DefenseItem defenseItem = (DefenseItem)item;
                Defense += defenseItem.DamageReduction;
            }
            else
            {
                Console.WriteLine("EmptyChest");
            }
        }

        /// <summary>
        /// If you are low on hp you go berserk and do damage * 2.
        /// </summary>
        public void BerserkMode()
        {
            this.Berserk = true;
            this.AttackPower *= 2;
            Console.WriteLine("You are low on health and have gone berserk");
        }
    }
}
