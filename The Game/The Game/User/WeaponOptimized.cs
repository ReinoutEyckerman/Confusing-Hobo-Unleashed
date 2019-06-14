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

        public WeaponOptimized(string weaponName, int damage, byte cooldown, Pixel pixel, int speed = 0)
        {
            Speed = speed;
            Name = weaponName;
            Damage = damage;
            this.pixel = pixel;
            Cooldown = cooldown;
            switch (Wtype)
            {
                case WeaponType.Fist:
                    UseAnimation = new char[3];
                    UseAnimation[0] = '°';
                    UseAnimation[1] = '°';
                    UseAnimation[2] = '°';
                    WeaponSound = new SoundPlayer(@"Sound Files\Punch.wav");
                    break;

                case WeaponType.Sword:
                    UseAnimation = new char[4];
                    UseAnimation[0] = '/';
                    UseAnimation[1] = '/';
                    UseAnimation[2] = '\\';
                    UseAnimation[3] = '\\';
                    WeaponSound = new SoundPlayer(@"Sound Files\Swipe.wav");
                    break;
                case WeaponType.Gun:
                    UseAnimation = new char[1];
                    UseAnimation[0] = '-';
                    WeaponSound = new SoundPlayer(@"Sound Files\Swipe.wav");
                    break;
                case WeaponType.Bomb:
                    UseAnimation = new char[1];
                    UseAnimation[0] = '-';
                    WeaponSound = new SoundPlayer(@"Sound Files\Swipe.wav");
                    break;
            }
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

        public string Name { get; set; }
        public WeaponType Wtype { get; set; }
        public int Damage { get; set; }
        public Pixel pixel { get; set; }
        public byte Cooldown { get; set; }
        public bool IsMelee { get; set; }
        public SoundPlayer WeaponSound { get; set; }
        public char[] UseAnimation { get; set; }

    }
}