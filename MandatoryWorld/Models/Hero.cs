using System;
using System.Diagnostics;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    /// <summary>
    /// The hero class, which inherits from Creature.
    /// </summary>
    public class Hero : Creature
    {
        public bool Berserk { get; set; }
        public string Name { get; set; }
        private HeroController _heroController = new HeroController();
        public Hero(string name) : base(name)
        {
            Name = name;
        }

        public void move()
        {
            _heroController.move(this);
        }

        public void Loot(Item item)
        {
            _heroController.Loot(item, this);
        }

        public void BerserkMode()
        {
            _heroController.BerserkMode(this);
        }
    }
}
