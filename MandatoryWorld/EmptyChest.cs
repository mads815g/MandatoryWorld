using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld 
{
    /// <summary>
    /// This is the class for if you have already looted the chest, it inherits from Item.
    /// </summary>
    public class EmptyChest : Item
    {
        public EmptyChest(string name) : base(name)
        {
        }
    }
}
