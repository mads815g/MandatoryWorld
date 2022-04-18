﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// This is the monster factory that makes trolls.
    /// </summary>
    public class MonsterFactory : MonsterFactoryAbstract
    {
        /// <summary>
        /// This is the create method that makes trolls
        /// </summary>
        /// <returns>This one returns trolls</returns>
        public override Creature CreateCreature()
        {
            return new Monster("Troll");
        }
    }
}
