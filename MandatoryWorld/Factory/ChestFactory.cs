using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Factory
{
    /// <summary>
    /// This is the chest factory that creates chests.
    /// </summary>
    public class ChestFactory : ChestFactoryAbstract
    {
        /// <summary>
        /// This method makes chests
        /// </summary>
        /// <returns>It returns a Chest object</returns>
        public override Chest CreateChest()
        {
            return new Chest();
        }
    }
}
