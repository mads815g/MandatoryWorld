using System;

namespace MandatoryWorld
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public bool IsDead { get; set; }

        protected Creature(string name)
        {
            Name = name;
            Defense = 0;
            IsDead = false;
        }

        public int hit()
        {
            Random rng = new Random();
            int damage = rng.Next(AttackPower);
            return damage;
        }

        public void RecieveHit(int damageTaken)
        {
            if (damageTaken <= Defense)
            {
                CurrentHitPoints -= 0;
            }
            else
            {
                CurrentHitPoints -= (damageTaken - Defense);
            }

            if (CurrentHitPoints <= 0)
            {
                IsDead = true;
                Console.WriteLine($"{Name} is dead");
            }
            Console.WriteLine($"{Name} has {CurrentHitPoints} HP left");
        }
    }
}
