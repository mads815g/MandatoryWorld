using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// The abstract monster factory
    /// </summary>
    public abstract class MonsterFactoryAbstract
    {
        public abstract Creature CreateCreature();
    }
}
