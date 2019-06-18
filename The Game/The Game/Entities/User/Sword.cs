using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes.Animations;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.User
{
    public class Sword:Weapon
    {
        private Animation _animation;
        //'/';
        // '/';
        // '\\';
        // '\\';
        // new SoundPlayer(@"Sound Files\Swipe.wav");
        public Sword(int damage, byte cooldown, Pixel pixel, int speed = 0) : base(damage, cooldown, pixel, speed)
        {
        }

        public override void Use(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}