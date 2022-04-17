using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    public class ChestFactory : ChestFactoryAbstract
    {
        public override Chest CreateChest()
        {
            return new Chest();
        }
    }
}
