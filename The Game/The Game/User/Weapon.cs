using System;
using System.Media;
using Confusing_Hobo_Unleashed.AI;

namespace Confusing_Hobo_Unleashed.User
{
    internal enum WeaponType
    {
        Fist,
        Sword
        ,
        Gun,
        Bomb
    }

    internal class Weapon
    {
        private readonly char _bulletChar;
        private readonly short _bulletColor;
        private int _speed;

        public Weapon(string weaponName, WeaponType type, int damage, byte cooldown, ConsoleColor color = ConsoleColor.Black, ConsoleColor bulletBackground = ConsoleColor.Black, ConsoleColor bulletForeground = ConsoleColor.Black, char bulletCharacter = 'o', int speed = 0)
        {
            Speed = speed;
            Name = weaponName;
            Wtype = type;
            Damage = damage;
            Color = color;
            Cooldown = cooldown;
            _bulletColor = Confusing_Hobo_Unleashed.Color.ColorsToAttribute(bulletBackground, bulletForeground);
            _bulletChar = bulletCharacter;
            switch (Wtype)
            {
                case WeaponType.Fist:
                    UseAnimation = new char[3];
                    UseAnimation[0] = '°';
                    UseAnimation[1] = '°';
                    UseAnimation[2] = '°';
                    IsMelee = true;
                    WeaponSound = new SoundPlayer(@"Sound Files\Punch.wav");
                    break;

                case WeaponType.Sword:
                    UseAnimation = new char[4];
                    UseAnimation[0] = '/';
                    UseAnimation[1] = '/';
                    UseAnimation[2] = '\\';
                    UseAnimation[3] = '\\';
                    IsMelee = true;
                    WeaponSound = new SoundPlayer(@"Sound Files\Swipe.wav");
                    break;
                case WeaponType.Gun:
                    UseAnimation = new char[1];
                    UseAnimation[0] = '-';
                    IsMelee = false;
                    WeaponSound = new SoundPlayer(@"Sound Files\Swipe.wav");
                    break;
                case WeaponType.Bomb:
                    UseAnimation = new char[1];
                    UseAnimation[0] = '-';
                    IsMelee = false;
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
        public ConsoleColor Color { get; set; }
        public byte Cooldown { get; set; }
        public bool IsMelee { get; set; }
        public SoundPlayer WeaponSound { get; set; }

        public char[] UseAnimation { get; set; }

        public void Shoot(int direction, int x, int y)
        {
            if (Wtype == WeaponType.Bomb)
            {
                if (VarDatabase.Invertrate == 1)
                    direction = 2*100 + direction%100;

                else
                    direction = 3*100 + direction%100;
            }
            direction += Speed;
            Game.Bullets.Add(new BulletCore(_bulletColor, _bulletChar, (short) Damage, direction, (short) x, (short) y));
        }
    }
}