using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class RegularHarpy : Enemy
    {
        public RegularHarpy(CustomMap map) : base(map)
        {
            WeaponInv = new Dictionary<byte, Weapon>();
            WeaponInv[0] = new Weapon("Fist", WeaponType.Fist, 2, 5);
            CurrentClass = Classes.Harpy;
            CanFly = true;
        }

        public override short X
        {
            get => _x;
            set
            {
                if (Target != null)
                    if (X - Target.X > _originalmaxhorizontalproximity + 10 ||
                        Target.X - X > _originalmaxhorizontalproximity + 10)
                    {
                        if (Y - 10 > 0)
                            MinVerticalProximity = 10;
                        else if (Y - 5 > 0)
                            MinVerticalProximity = 5;
                        MaxVerticalProximity = Map.Mapheight;
                    }
                    else
                    {
                        MinVerticalProximity = -4;
                        MaxVerticalProximity = 0;
                    }

                _x = value;
            }
        }

        public override void CalculateAttack()
        {
            switch (Target.X - X)
            {
                case 1:
                    if (Target.Y - Y == 0)
                        Attack(Map, Move.Right);
                    break;
                case -1:
                    if (Target.Y - Y == 0)
                        Attack(Map, Move.Left);
                    break;
                case 0:
                    switch (Target.Y - Y)
                    {
                        case 1:
                            Attack(Map, Move.Down);
                            break;
                        case -1:
                            Attack(Map, Move.Up);
                            break;
                    }

                    break;
            }
        }

        public override void SelectTarget()
        {
            Target = MainGame.Players[Random.Next(MainGame.Players.Count)];
        }

        public override void Special()
        {
            if (Mana - 200 > 0) Mana -= 200;
        }

        protected override void Damage()
        {
            throw new NotImplementedException();
        }
    }
}