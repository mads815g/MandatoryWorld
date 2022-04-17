namespace MandatoryWorld
{
    public class AttackItem : Item
    {
        public int Damage { get; set; }
        public AttackItem(string name, int damage) : base(name)
        {
            Damage = damage;
        }

    }
}
