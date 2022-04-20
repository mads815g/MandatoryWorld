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
    public abstract class Creature : Position
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public bool IsDead { get; set; }

        private List<IObserver> _observers = new List<IObserver>();
        /// <summary>
        /// The Creature class constructor
        /// </summary>
        /// <param name="name">name of the creature</param>
        protected Creature(string name)
        {
            Name = name;
            Defense = 0;
            IsDead = false;
        }

        /// <summary>
        /// This is the hit method that decides the dmg of your hit.
        /// </summary>
        /// <returns></returns>
        public int Hit()
        {
            Random rng = new Random();
            int damage = rng.Next(AttackPower);
            return damage;
        }

        /// <summary>
        /// This is the damage taken method the how much of the damagetaken that goes through.
        /// </summary>
        /// <param name="damageTaken">Original damage from hit</param>
        public void RecieveHit(int damageTaken)
        {
            if (damageTaken <= Defense)
            {
                CurrentHitPoints -= 0;
            }
            else
            {
                CurrentHitPoints -= (damageTaken - Defense);
                if (CurrentHitPoints < 0)
                {
                    CurrentHitPoints = 0;
                }
            }
            Console.WriteLine($"{Name} has {CurrentHitPoints} HP left");
            Tracing.TraceWorker($"{Name} has {CurrentHitPoints} HP left", TraceEventType.Information);

            if (CurrentHitPoints <= 0)
            {
                IsDead = true;
                Notify();
            }
        }
        
        /// <summary>
        /// This method checks if you are dead and have lost the game.
        /// </summary>
        public void GameOver()
        {
            if (this.IsDead)
            {
                Console.WriteLine("You have died, Game Over");
                Tracing.TraceWorker("You have died, Game Over", TraceEventType.Information);
                Console.ReadKey();
            }
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
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
