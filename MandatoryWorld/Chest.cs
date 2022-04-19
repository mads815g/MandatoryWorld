using System;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    /// <summary>
    /// This is the chest class, that inherits from position.
    /// </summary>
    public class Chest : Position
    {
        public string Name { get; set; }
        private static Random rng = new Random();
        public bool Looted { get; set; }

        /// <summary>
        /// The constructor for chest doesn't take parameters, because the position is randomly generated in Position, looted starts as false and the name is always chest.
        /// </summary>
        public Chest()
        {
            Name = "Chest";
            Looted = false;
        }

        /// <summary>
        /// This method checks if you have already looted the chest, if not then it randomly decides between a random attack or defensive item.
        /// </summary>
        /// <returns>Empty if looted else an attack or defensive item.</returns>
        public Item ContainedLoot()
        {
            if (Looted)
            {
                Console.WriteLine("You already Looted this chest");
                Tracing.TraceWorker("You already Looted this chest");
                return new EmptyChest("EmptyChest");
            }

            int result = rng.Next(0, 2);
            if (result == 1)
            {
                int damage = rng.Next(1, 5);
                Console.WriteLine("You got a Weapon");
                Tracing.TraceWorker("You got a Weapon");
                Looted = true;
                return new AttackItem("Weapon", damage);
            }

            int reduction = rng.Next(1, 5);
            Console.WriteLine("You got an Armor");
            Tracing.TraceWorker("You got an Armor");
            Looted = true;
            return new DefenseItem("Armor", reduction);
        }
    }
}
