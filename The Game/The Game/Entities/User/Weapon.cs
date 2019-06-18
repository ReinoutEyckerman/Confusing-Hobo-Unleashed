using System;
using System.Media;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.User
{
    public abstract class Weapon
    {
        private int _speed;
        //TODO Range?
        public Weapon( int damage, byte cooldown, Pixel pixel, int speed = 0)
        {
            Speed = speed;
            Damage = damage;
            this.pixel = pixel;
            Cooldown = cooldown;
        }

        public int Speed
        {
            get { return _speed; }
            set
            {
                if (_speed > 9) _speed = 9;
                _speed = value;
            }
        }

        public int Damage { get; set; }
        public Pixel pixel { get; set; }
        public byte Cooldown { get; set; }
        public bool IsMelee { get; set; }
        public SoundPlayer WeaponSound { get; set; }
        public char[] UseAnimation { get; set; }

        public abstract void Use(Direction direction);
        //TODO DestructibleCheck(xpos, ypos);

    }
}