using System;

namespace MandatoryWorld
{
    public class Monster : Creature
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Monster(string name) : base(name)
        {
            Random rng = new Random();
            PositionX = rng.Next(1, World.MaxX + 1);
            PositionY = rng.Next(1, World.MaxY + 1);
            if (PositionX == 1 && PositionY == 1)
            {
                PositionY = rng.Next(1, World.MaxY + 1);
            }
            HitPoints = rng.Next(30, 101);
            CurrentHitPoints = HitPoints;
            AttackPower = rng.Next(3, 11);
        }
    }
}
