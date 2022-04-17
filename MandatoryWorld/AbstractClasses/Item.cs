

using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    public abstract class Item
    {
        public string Name { get; set; }
        protected Item(string name)
        {
            Name = name;
        }

        
    }
}
