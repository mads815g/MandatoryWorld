using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// This is the goblin factory class.
    /// </summary>
    public class GoblinFactory : MonsterFactory
    {
        /// <summary>
        /// This is the method that makes Goblins
        /// </summary>
        /// <returns>It returns goblins</returns>
        public override Creature CreateCreature()
        {
            return new Monster("Goblin");
        }
    }
}
