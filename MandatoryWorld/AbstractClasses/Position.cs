using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.AbstractClasses
{
    public abstract class Position
    {
        public int PositionY { get; set; }
        public int PositionX { get; set; }

        public Position()
        {
            Random rng = new Random();
            PositionX = rng.Next(1, 10);
            PositionY = rng.Next(1, 10);
        }
    }
}
