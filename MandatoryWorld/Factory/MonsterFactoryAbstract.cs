using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// The abstract monster factory
    /// </summary>
    public abstract class MonsterFactoryAbstract
    {
        public Monster CreateCreature()
        {
            var rng = new Random();

            var (minHitPoints, maxHitPoints) = GetHitPointRange();
            var (minAttackPower, maxAttackPower) = GetAttackPowerRange();
            var hitPoints = rng.Next(minHitPoints, maxHitPoints);
            var name = GetName();
            return new Monster(name)
            {
                Name = name,
                HitPoints = hitPoints,
                CurrentHitPoints = hitPoints,
                AttackPower = rng.Next(minAttackPower, maxAttackPower),
                Position = InitiatePosition()
            };
        }

        private Position InitiatePosition()
        {
            var rng = new Random();
            var x = rng.Next(1, World.MaxX + 1);
            var y = rng.Next(1, World.MaxY + 1);
            if (x == 1 && y == 1)
            {
                y = rng.Next(1, World.MaxY + 1);
            }
            return new Position
            {
                PositionX = x,
                PositionY = y,
            };
        }

        public abstract string GetName();
        protected abstract (int, int) GetAttackPowerRange();

        protected abstract (int, int) GetHitPointRange();
    }
}
