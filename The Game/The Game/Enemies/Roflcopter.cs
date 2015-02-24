using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Roflcopter : AiCore
    {
        private bool _raining;

        public Roflcopter(CustomMap map) : base(map)
        {
            Background = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
            Foreground = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].White;
            DrawChar = 'T';
            HpTotal = 35;
            HpCurrent = (int) HpTotal;
            MaxMana = 1000;
            Mana = 600;
            CanFly = true;
            MovementMinTime = 2;
            MaxHorizontalProximity = MinHorizontalProximity;
            MinVerticalProximity = 10;
            CurrentClass = Classes.Roflcopter;
            MaxVerticalProximity = 30;
            PlayerColor = Color.ColorsToAttribute(Background, Foreground);
            WeaponInv = new Dictionary<byte, Weapon>();
            WeaponInv[0] = new Weapon("Bomb", WeaponType.Bomb, 2, 10,
                bulletBackground: VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].White,
                bulletForeground: VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black, speed: 1);
        }

        public override void CalculateAttack()
        {
            if (Target != null && Target.X - X < 3 && X - Target.X < 3)
                Attack(Map, Move.Down);
        }

        public override void SelectTarget()
        {
            if (Mana%50 == 0 || Target == null)
                Target = Game.Players[Random.Next(Game.Players.Count)];
        }

        public override void Special()
        {
            if (Mana - 900 > 0)
            {
                _raining = true;
                Mana -= 750;
            }
            if (_raining && Mana > 0)
            {
                var vert = 0;
                if (VarDatabase.Invertrate == 1)
                    vert = Map.Mapheight - 1;
                WeaponInv[0].Shoot(300, Random.Next(Map.Mapwidth), vert);
                Mana -= 5;
                if (Mana < 0)
                    _raining = false;
            }
        }
    }
}