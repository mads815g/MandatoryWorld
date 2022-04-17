using System;

namespace MandatoryWorld
{
    public class Hero : Creature
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Hero(string name, int hitPoints, int attackPower) : base(name)
        {
            PositionX = 1;
            PositionY = 1;
            HitPoints = hitPoints;
            CurrentHitPoints = HitPoints;
            AttackPower = attackPower;
        }

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

        public void Loot(Item item)
        {
            if (item.GetType().Name == "AttackItem")
            {
                AttackItem attackItem = (AttackItem)item;
                AttackPower += attackItem.Damage;
            } 
            else if (item.GetType().Name == "DefenceItem")
            {
                DefenceItem defenceItem = (DefenceItem)item;
                Defense += defenceItem.DamageReduction;
            }
            else
            {
                Console.WriteLine("EmptyChest");
            }
        }
    }
}
