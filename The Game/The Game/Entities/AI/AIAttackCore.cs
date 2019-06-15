using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.AI
{
    abstract partial class AiCore
    {
        private Move _attackDirection = Move.None;
        public byte AttackCooldown { get; set; }
        public Dictionary<byte, Weapon> WeaponInv { get; set; }
        public AiCore Target { get; set; }
        public abstract void CalculateAttack();

        public void Melee()
        {
            Proximity = 1;
            WeaponInv[0] = new Weapon("Fist", WeaponType.Fist, 3, 3, ConsoleColor.DarkCyan);
        }

        public virtual void MeleeCheck(AiCore source, int xpos, int ypos)
        {
            foreach (var t in MainGame.Entities)
            {
                if (t.X == xpos && t.Y == ypos)
                    t.HpCurrent -= source.WeaponInv[0].Damage;
            }

            DestructibleCheck(xpos, ypos);
        }

        public void Attack(CustomMap map, Move direction)
        {
            if (AttackCooldown == 0)
            {
                _attackDirection = direction;
                switch (direction)
                {
                    case Move.Left:
                        if (X - 1 >= 0)
                            AttackAnimation(X - 1, Y);
                        break;
                    case Move.Right:
                        if (X + 1 < map.Mapwidth)
                            AttackAnimation(X + 1, Y);
                        break;
                    case Move.Up:
                        if (Y - 1 >= 0)
                            AttackAnimation(X, Y - 1);
                        break;
                    case Move.Down:
                        if (Y + 1 < map.Mapheight)
                            AttackAnimation(X, Y + 1);
                        break;
                }
            }
        }

        private void AttackAnimation(int x, int y)
        {
            AnimHitFrame = (byte) WeaponInv[0].UseAnimation.Length;
            AttackCooldown = WeaponInv[0].Cooldown;
            if (WeaponInv[0].IsMelee)
                MeleeCheck(this, x, y);
            else
                WeaponInv[0].Shoot((byte) _attackDirection * 100, x, y);
        }

        private void DestructibleCheck(int xpos, int ypos)
        {
            if (MainGame.CurrentLoadedMap.Destructible[ypos, xpos])
            {
                Server.Change = true;
                if (MainGame.CurrentLoadedMap.Collision[ypos, xpos])
                {
                    MainGame.CurrentLoadedMap.CollisionBackUp[ypos, xpos] = false;
                    MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[ypos, xpos] = null;
                }

                MainGame.CurrentLoadedMap.Destructible[ypos, xpos] = false;
                MainGame.CurrentLoadedMap.Layers[Maplayers.Destructible].Characters[ypos, xpos] = null;
            }
        }
    }
}