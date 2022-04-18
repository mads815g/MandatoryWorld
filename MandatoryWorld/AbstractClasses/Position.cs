using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.AbstractClasses
{
    /// <summary>
    /// The Class that gives chests and creatures their position variables.
    /// </summary>
    public abstract class Position
    {
        public int PositionY { get; set; }
        public int PositionX { get; set; }

        /// <summary>
        /// Position constructor where your position in the world is randomly generated.
        /// </summary>
        public Position()
        {
            Random rng = new Random();
            PositionX = rng.Next(1, World.MaxX + 1);
            PositionY = rng.Next(1, World.MaxY + 1);
            if (PositionX == 1 && PositionY == 1)
            {
                PositionY = rng.Next(1, World.MaxY + 1);
            }
        }
    }
}
