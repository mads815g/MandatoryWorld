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
    public class GoblinFactory : MonsterFactoryAbstract
    {
        protected override (int, int) GetAttackPowerRange()
        {
            return (3, 10);
        }

        protected override (int, int) GetHitPointRange()
        {
            return (30, 100);
        }
    }
}
