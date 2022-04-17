using System;
using System.Collections.Generic;
using System.Linq;

namespace MandatoryWorld
{
    public class DefenceItem : Item
    {
        public int DamageReduction { get; set; }
        public DefenceItem(string name, int damageReduction) : base(name)
        {
            DamageReduction = damageReduction;
        }       
    }
}
