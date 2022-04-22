using System;
using System.Collections.Generic;
using System.Diagnostics;
using MandatoryWorld.AbstractClasses;
using MandatoryWorld.Observers;

namespace MandatoryWorld
{
    /// <summary>
    /// The creature class, which inherits from Position,
    /// </summary>
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public bool IsDead { get; set; }
        public Position Position { get; set; }

        private List<IObserver> _observers = new List<IObserver>();
        private CreatureController _creatureController = new CreatureController();
        /// <summary>
        /// The Creature class constructor
        /// </summary>
        /// <param name="name">name of the creature</param>
        public Creature(string name)
        {
            Name = name;
            Defense = 0;
            IsDead = false;
        }

       
        public int Hit()
        {
            return _creatureController.Hit(this);
        }

        public void RecieveHit(int damageTaken)
        {
            _creatureController.RecieveHit(damageTaken, this);
        }

        public void GameOver()
        {
            _creatureController.GameOver(this);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
