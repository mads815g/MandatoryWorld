using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    public class MonsterFactory : MonsterFactoryAbstract
    {
        public override Monster CreateTrolls()
        {
            return new Monster("Troll");
        }

        public override Monster CreateGoblins()
        {
            return new Monster("Goblin");
        }
    }
}
