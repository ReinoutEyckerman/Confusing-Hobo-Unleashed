using System;
using System.Media;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.User
{

    internal class WeaponOptimized
    {
        private int _speed;

        public WeaponOptimized( int damage, byte cooldown, Pixel pixel, int speed = 0)
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

    }
}