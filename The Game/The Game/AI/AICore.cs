using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.AI
{
    internal enum Classes
    {
        Zerg,
        Roflcopter,
        Harpy,
        Necromancer,
        Grave,
        Player,
        Boss
    }

    abstract partial class AiCore
    {
        public readonly Random Random = new Random();
        private int? _hptotal;
        private short _x;
        private short _y;
        public Classes CurrentClass;

        protected AiCore(CustomMap map)
        {
            Map = map;
        }

        protected AiCore(CustomMap map, short xpos, short ypos, int totalHp, char playerCharacter, ConsoleColor backGround, ConsoleColor foreGround)
        {
            Map = map;

            X = xpos;
            Y = ypos;
            HpTotal = totalHp;
            HpCurrent = totalHp;
            DrawChar = playerCharacter;
            Background = backGround;
            Foreground = foreGround;
            AnimHitFrame = 0;
            AttackCooldown = 0;
            PlayerColor = Painter.Instance.ColorsToAttribute(Background, Foreground);
            SpeedY = 0;
            WeaponInv = new Dictionary<byte, Weapon>();
            GenerateClass();
        }

        public CustomMap Map { get; set; }
        protected int MaxMana { get; set; }
        public int Mana { get; set; }
        public char DrawChar { get; set; }
        public ConsoleColor Background { get; set; }
        public ConsoleColor Foreground { get; set; }
        public short PlayerColor { get; set; }

        public virtual short X
        {
            get { return _x; }
            set
            {
                if (value >= 0)
                {
                    _x = value;
                }
            }
        }

        public virtual short Y
        {
            get { return _y; }
            set
            {
                if (value >= 0)
                {
                    _y = value;
                }
            }
        }

        public int SpeedY { get; set; }

        public int? HpTotal
        {
            get { return _hptotal; }
            set
            {
                if (value > 0)
                {
                    _hptotal = value;
                }
            }
        }

        public int HpCurrent { get; set; }
        public bool FacingRight { get; set; }
        public byte AnimHitFrame { get; set; }
        public int Proximity { get; set; }

        public void Render(buffer outputbuffer, CustomMap map)
        {
            var playerchar = Convert.ToString(DrawChar);
            outputbuffer.Draw(playerchar, X, Y, PlayerColor);

            if (AnimHitFrame > 0)
            {
                var nextAnimFrame = WeaponInv[0].UseAnimation.Length - AnimHitFrame;
                var stringToDraw = Convert.ToString(WeaponInv[0].UseAnimation[nextAnimFrame]);
                short color;
                switch (_attackDirection)
                {
                    case Move.Left:
                        color = Painter.Instance.ColorsToAttribute(map.Background[Y, X - 1], WeaponInv[0].Color);
                        outputbuffer.Draw(stringToDraw, X - 1, Y, color);
                        break;
                    case Move.Up:
                        color = Painter.Instance.ColorsToAttribute(map.Background[Y - 1, X], WeaponInv[0].Color);
                        outputbuffer.Draw(stringToDraw, X, Y - 1, color);
                        break;
                    case Move.Right:
                        color = Painter.Instance.ColorsToAttribute(map.Background[Y, X + 1], WeaponInv[0].Color);
                        outputbuffer.Draw(stringToDraw, X + 1, Y, color);
                        break;
                    case Move.Down:
                        color = Painter.Instance.ColorsToAttribute(map.Background[Y + 1, X], WeaponInv[0].Color);
                        outputbuffer.Draw(stringToDraw, X, Y + 1, color);
                        break;
                }
            }
        }

        public abstract void Special();

        public void UpdateMana()
        {
            if (Mana < MaxMana)
                Mana++;
        }

        public void ChooseWeapon()
        {
        }

        public void GenerateClass()
        {
            if (Random.Next(2) == 0)
            {
            }
            Melee();
        }

        public void Update()
        {
            if (AnimHitFrame > 0)
            {
                AnimHitFrame--;
            }
            if (AttackCooldown > 0)
            {
                AttackCooldown--;
            }
        }

        public void SwapWeapon()
        {
            var temp = WeaponInv[0];
            WeaponInv[0] = WeaponInv[1];
            WeaponInv[1] = temp;
        }

        public virtual void SetSpawn()
        {
            X = 0;
            Y = 0;
            for (var xpos = Convert.ToInt16(Map.Mapwidth - 1); xpos >= 0; xpos--)
            {
                for (short ypos = 0; ypos < Map.Mapheight; ypos++)
                {
                    if (Map.Grav[ypos, xpos] >= 0)
                    {
                        if (ypos + 1 < Map.Mapheight && !Map.Collision[ypos, xpos] && Map.Collision[ypos + 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                    }
                    else if (Map.Grav[ypos, xpos] < 0)
                        if (ypos - 1 > 0 && !Map.Collision[ypos, xpos] && Map.Collision[ypos - 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                }
                if (X != 0 || Y != 0)
                    break;
            }
        }
    }
}