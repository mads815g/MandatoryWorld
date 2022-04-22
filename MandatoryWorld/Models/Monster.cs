using MandatoryWorld.AbstractClasses;
using System;
using System.Diagnostics;

namespace MandatoryWorld
{
    /// <summary>
    /// The monster class where the random monsters are made, it inherits from Creature.
    /// </summary>
    public class Monster : Creature
    {
        public Monster(string name) : base(name)
        {
        }
    }
}
