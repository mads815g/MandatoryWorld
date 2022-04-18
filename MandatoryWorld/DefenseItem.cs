using System;
using System.Collections.Generic;
using System.Linq;

namespace MandatoryWorld
{
    /// <summary>
    /// This is the class for the defense item, it inherits from Item.
    /// </summary>
    public class DefenseItem : Item
    {
        public int DamageReduction { get; set; }
        /// <summary>
        /// This is the constructor for the defense item class.
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="damageReduction">The amount of damage reduction it provides</param>
        public DefenseItem(string name, int damageReduction) : base(name)
        {
            DamageReduction = damageReduction;
        }       
    }
}
