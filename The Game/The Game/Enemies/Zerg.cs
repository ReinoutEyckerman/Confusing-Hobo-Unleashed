using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Zerg : AiCore
    {
        public Zerg(CustomMap map) : base(map)
        {
            Background = Painter.Instance.Paint(ConsoleColor.DarkRed);
            Foreground = Painter.Instance.Paint(ConsoleColor.White);
            DrawChar = '7';
            HpTotal = 5;
            HpCurrent = (int) HpTotal;
            MaxMana = 400;
            Mana = 50;
            MinVerticalProximity = 0;
            MinHorizontalProximity = 0;
            MaxHorizontalProximity = 0;
            MaxVerticalProximity = 0;
            PlayerColor = Color.ColorsToAttribute(Background, Foreground);
            WeaponInv = new Dictionary<byte, Weapon>();
            WeaponInv[0] = new Weapon("Fist", WeaponType.Fist, 2, 5);
            CurrentClass = Classes.Zerg;
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
            Target = Game.Players[Random.Next(Game.Players.Count)];
        }

        public override void Special()
        {
            if (Mana - 350 > 0)
            {
                Game.Entities.Add(new Zerg(Map));
                Game.Entities[Game.Entities.Count - 1].SetSpawn();
                Mana -= 350 + Random.Next(-50, 50);
            }
        }
    }
}