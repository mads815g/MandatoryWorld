using MandatoryWorld.AbstractClasses;
using System;

namespace MandatoryWorld
{
    /// <summary>
    /// The monster class where the random monsters are made, it inherits from Creature.
    /// </summary>
    public class Monster : Creature
    {
        /// <summary>
        /// This is the monster class constructor. it only has a single responsibility and that is creating a monster with random monster hp, attack power and position. 
        /// </summary>
        /// <param name="name">The name of the monster</param>
        public Monster(string name) : base(name)
        {
            Random rng = new Random();
            HitPoints = rng.Next(30, 101);
            CurrentHitPoints = HitPoints;
            AttackPower = rng.Next(3, 11);
        }
    }
}
