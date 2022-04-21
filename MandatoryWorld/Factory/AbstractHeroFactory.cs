
using MandatoryWorld.AbstractClasses;

namespace MandatoryWorld.Factory
{
    public class AbstractHeroFactory
    {
        public Hero CreateHero(string name, int attackPower, int hp)
        {
            return new Hero(name)
            {
                Name = name,
                Position = InitiatePosition(),
                Defense = 0,
                Berserk = false,
                AttackPower = attackPower,
                HitPoints = hp,
                CurrentHitPoints = hp
            };
        }

        private Position InitiatePosition()
        {
            return new Position
            {
                PositionX = 1,
                PositionY = 1,
            };
        }
    }
}
