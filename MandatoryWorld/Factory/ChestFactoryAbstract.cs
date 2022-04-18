using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// This is the abstract chest factory.
    /// </summary>
    public abstract class ChestFactoryAbstract
    {
        public abstract Chest CreateChest();
    }
}
