using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// This is the abstract chest factory.
    /// </summary>
    public abstract class ChestFactoryAbstract
    {
        public Chest CreateChest()
        {
            var rng = new Random();
            return new Chest()
            {
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
    }
}
