using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    public abstract class MonsterFactoryAbstract
    {
        public abstract Monster CreateTrolls();
        public abstract Monster CreateGoblins();
    }
}
