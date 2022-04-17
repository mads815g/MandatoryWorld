using System;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    public class Chest : Position
    {
        public string Name { get; set; }
        private static Random rng = new Random();
        public bool Looted { get; set; }

        public Chest()
        {
            Name = "Chest";
            PositionX = rng.Next(1, World.MaxX + 1);
            PositionY = rng.Next(1, World.MaxY + 1);
            if (PositionX == 1 && PositionY == 1)
            {
                PositionY = rng.Next(1, World.MaxY + 1);
            }

            Looted = false;
        }

        public Item ContainedLoot()
        {
            if (Looted == true)
            {
                Console.WriteLine("You already Looted this chest");
                return new EmptyChest("EmptyChest");
            }

            int result = rng.Next(0, 2);
            if (result == 1)
            {
                int damage = rng.Next(1, 5);
                Console.WriteLine("You got a Weapon");
                Looted = true;
                return new AttackItem("Weapon", damage);
            }

            int reduction = rng.Next(1, 5);
            Console.WriteLine("You got an Armor");
            Looted = true;
            return new DefenceItem("Armor", reduction);
        }
    }
}
