using System;
using System.Diagnostics;

namespace MandatoryWorld
{
    /// <summary>
    /// The hero class, which inherits from Creature.
    /// </summary>
    public class Hero : Creature, IMove
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
            Console.WriteLine($"{Name} is at {PositionX}, {PositionY}");
            Tracing.TraceWorker($"{Name} is at {PositionX}, {PositionY}", TraceEventType.Information);
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
                        Console.WriteLine($"{Name} is at the top");
                        Tracing.TraceWorker($"{Name} is at the top", TraceEventType.Information);
                    }
                    break;
                case ConsoleKey.A:
                    if (PositionX > 1)
                    {
                        PositionX -= 1;
                    }
                    else
                    {
                        Console.WriteLine($"{Name} can't go further left");
                        Tracing.TraceWorker($"{Name} can't go further left", TraceEventType.Information);
                    }
                    break;
                case ConsoleKey.D:
                    if (PositionX < World.MaxX)
                    {
                        PositionX += 1;
                    }
                    else
                    {
                        Console.WriteLine($"{Name} can't go further Right");
                        Tracing.TraceWorker($"{Name} can't go further Right", TraceEventType.Information);
                    }
                    break;
                case ConsoleKey.S:
                    if (PositionY > 1)
                    {
                        PositionY -= 1;
                    }
                    else
                    {
                        Console.WriteLine($"{Name} can't go further Down");
                        Tracing.TraceWorker($"{Name} can't go further Down", TraceEventType.Information);
                    }
                    break;
                default:
                    Console.WriteLine($"{Name} is not moving");
                    Tracing.TraceWorker($"{Name} is not moving", TraceEventType.Information);
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
                Console.WriteLine($"{Name} now have {AttackPower} attack and {Defense} defense");
                Tracing.TraceWorker($"{Name} now have {AttackPower} attack and {Defense} defense", TraceEventType.Information);
            } 
            else if (item.GetType().Name == "DefenseItem")
            {
                DefenseItem defenseItem = (DefenseItem)item;
                Defense += defenseItem.DamageReduction;
                Console.WriteLine($"{Name} now have {AttackPower} attack and {Defense} defense");
                Tracing.TraceWorker($"{Name} now have {AttackPower} attack and {Defense} defense", TraceEventType.Information);
            }
        }

        /// <summary>
        /// If you are low on hp you go berserk and do damage * 2.
        /// </summary>
        public void BerserkMode()
        {
            Berserk = true;
            AttackPower *= 2;
            Console.WriteLine($"{Name} are low on health and have gone berserk");
            Tracing.TraceWorker($"{Name} are low on health and have gone berserk", TraceEventType.Information);
        }
    }
}
