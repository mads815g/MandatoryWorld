

using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld
{
    /// <summary>
    /// Item Class
    /// </summary>
    public abstract class Item
    {
        public string Name { get; set; }
        /// <summary>
        /// Item class constructor.
        /// </summary>
        /// <param name="name">Name of the item</param>
        protected Item(string name)
        {
            Name = name;
        }
    }
}
