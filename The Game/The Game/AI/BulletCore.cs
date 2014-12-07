using System;
using Confusing_Hobo_Unleashed.Map;
using Confusing_Hobo_Unleashed.Multiplayer;

namespace Confusing_Hobo_Unleashed.AI
{
    internal class BulletCore
    {
        private readonly int _direction;
        public short BulletColor;
        public char Character;
        public short Damage;
        public short X;
        public short Y;
        public bool Rendered = false;

        public BulletCore()
        {
            Character = 'o';
            BulletColor = Color.ColorsToAttribute(VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black, VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].White);
            Damage = 10;
        }

        public BulletCore(short bulletcolor, char character, short damage, int direction, short x, short y)
        {
            X = x;
            Y = y;
            _direction = direction;
            Damage = damage;
            Character = character;
            BulletColor = bulletcolor;
        }

        public void Render(buffer outputbuffer, CustomMap map)
        {
            string bulletchar = Convert.ToString(Character);
            outputbuffer.Draw(bulletchar, X, Y, BulletColor);
        }

        public bool CalculateMovement(CustomMap map)
        {
            int tempDirection = 0;
            switch (_direction/100)
            {
                case 0:

                    tempDirection = -1;
                    break;
                case 1:
                    tempDirection = 1;
                    break;
                case 2:
                    tempDirection = -2;
                    break;
                case 3:
                    tempDirection = 2;
                    break;
            }
            switch (tempDirection)
            {
                case 1:
                case -1:

                    for (int x = 0; x <= _direction%100; x++)
                    {
                        if (X + x*tempDirection >= map.Mapwidth || X + x*tempDirection < 0)
                            return true;
                        foreach (AiCore entity in Game.Entities)
                        {
                            if (entity.X == X + x*tempDirection && entity.Y == Y)
                            {
                                DealDamage(entity);
                                return true;
                            }
                        }
                        if (map.Destructible[Y, X + x*tempDirection])
                        {
                            Server.Change = true;
                            if (map.Collision[Y, X + x*tempDirection])
                            {
                                map.Layers[Maplayers.Destructible].Characters[Y, X + x*tempDirection] = map.Layers[Maplayers.Collision].Characters[Y, X + x*tempDirection] = null;
                                map.Destructible[Y, X + x*tempDirection] = map.Collision[Y, X + x*tempDirection] = false;
                            }
                            else
                            {
                                map.Destructible[Y, X + x*tempDirection] = false;
                                map.Layers[Maplayers.Destructible].Characters[Y, X + x*tempDirection] = null;
                            }
                            return true;
                        }
                        if (map.Collision[Y, X + x*tempDirection])
                        {
                            return true;
                        }
                    }
                    X += Convert.ToInt16(_direction%100*tempDirection);

                    break;
                case 2:
                case -2:

                    for (int y = 0; y <= _direction%100; y++)
                    {
                        if (Y + y*tempDirection/2 >= map.Mapheight || Y + y*tempDirection/2 < 0)
                            return true;
                        foreach (AiCore entity in Game.Entities)
                        {
                            if (entity.X == X && entity.Y == Y + y*tempDirection/2)
                            {
                                DealDamage(entity);
                                return true;
                            }
                        }
                        if (map.Destructible[Y + y*tempDirection/2, X])
                        {
                            Server.Change = true;
                            if (map.Collision[Y + y*tempDirection/2, X])
                            {
                                map.Layers[Maplayers.Destructible].Characters[Y + y*tempDirection/2, X] = map.Layers[Maplayers.Collision].Characters[Y + y*tempDirection/2, X] = null;
                                map.Destructible[Y + y*tempDirection/2, X] = map.Collision[Y + y*tempDirection/2, X] = false;
                            }
                            else
                            {
                                map.Destructible[Y + y*tempDirection/2, X] = false;
                                map.Layers[Maplayers.Destructible].Characters[Y + y*tempDirection/2, X] = null;
                            }
                            return true;
                        }
                        if (map.Collision[Y + y*tempDirection/2, X])
                        {
                            return true;
                        }
                    }
                    Y += Convert.ToInt16(_direction%100*tempDirection/2);
                    break;
            }
            return false;
        }

        private void DealDamage(AiCore target)
        {
            target.HpCurrent -= Damage;
        }
    }
}