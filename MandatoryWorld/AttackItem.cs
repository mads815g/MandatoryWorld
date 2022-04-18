namespace MandatoryWorld
{
    /// <summary>
    /// Attack item class which inherits from Item.
    /// </summary>
    public class AttackItem : Item
    {
        public int Damage { get; set; }
        /// <summary>
        /// The attack item constructor.
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <param name="damage">damage amount of the item</param>
        public AttackItem(string name, int damage) : base(name)
        {
            Damage = damage;
        }

    }
}
