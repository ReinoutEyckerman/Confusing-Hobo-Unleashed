using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes.Animations;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.User
{
    public class Fist : Weapon

    {
        private Animation _animation;

        // '°';
        // '°';
        // '°';
        // range =1;
        private static readonly int speed = 3;
        private static readonly int damage = 3;

        public Fist( byte cooldown, Pixel pixel) : base(damage, cooldown, pixel, speed)
        {
        }

        public override void Use(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}