using System;
using System.Collections.Generic;
using System.Text;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Necromancer : AiCore
    {
        private short _timer;

        public Necromancer(CustomMap map) : base(map)
        {
            Background = Painter.Instance.Paint(ConsoleColor.Green);
            Foreground = Painter.Instance.Paint(ConsoleColor.Black,true);
            DrawChar = Encoding.GetEncoding(437).GetChars(new byte[] {127})[0];
            HpTotal = 40;
            HpCurrent = (int) HpTotal;
            MinHorizontalProximity = 20 + Random.Next(-5, 6);
            MaxHorizontalProximity = 1;
            MaxVerticalProximity = 1;
            PlayerColor = Painter.Instance.ColorsToAttribute(Background, Foreground);
            WeaponInv = new Dictionary<byte, Weapon>();
            WeaponInv[0] = new Weapon("Iron Sword", WeaponType.Sword, 10, 5);
            CurrentClass = Classes.Necromancer;
            MaxMana = 310;
        }

        public override void CalculateAttack()
        {
        }

        public override void SelectTarget()
        {
            _timer++;
            if (Target == null || _timer > 50 && Target.CurrentClass != Classes.Grave)
            {
                _timer = 0;
                foreach (var t in Game.Entities)
                {
                    if (t.CurrentClass == Classes.Grave)
                    {
                        Target = t;
                        MinHorizontalProximity /= 3;
                        MaxHorizontalProximity = 1;
                        MaxVerticalProximity = 1;
                        return;
                    }
                }

                Target = Game.Players[Random.Next(Game.Players.Count)];
                MinHorizontalProximity = 20 + Random.Next(-5, 6);
                MaxHorizontalProximity = 1;
                MaxVerticalProximity = 1;
            }
        }

        public override void Special()
        {
            if (Mana - 40 > 0 && Target.CurrentClass == Classes.Grave)
            {
                for (var index = 0; index < Game.Entities.Count; index++)
                {
                    if (Game.Entities[index].CurrentClass == Classes.Grave)
                    {
                        var tempx = X - Game.Entities[index].X;
                        var tempy = Y - Game.Entities[index].Y;
                        if (tempx < 10 && tempx > -10 && tempy < 5 && tempy > -5)
                        {
                            Mana -= 40;
                            Game.Entities[index].Special();
                            Game.Entities.RemoveAt(index);
                            Target = null;
                        }
                    }
                }
            }
        }
    }

    internal class Grave : AiCore
    {
        private readonly AiCore _graveBot;

        public Grave(CustomMap map, AiCore bot) : base(map)
        {
            X = bot.X;
            Y = bot.Y;
            _graveBot = bot;
            DrawChar = Encoding.GetEncoding(437).GetChars(new byte[] {127})[0];
            Background = Painter.Instance.Paint(ConsoleColor.DarkGray);
            Foreground = Painter.Instance.Paint(ConsoleColor.White);
            CurrentClass = Classes.Grave;
            HpCurrent = 15;
        }

        public override void CalculateAttack()
        {
        }

        public override void SelectTarget()
        {
        }

        public override void Movement(CustomMap map)
        {
        }

        public override void Special()
        {
            if (_graveBot.HpTotal != null) _graveBot.HpCurrent = (int) _graveBot.HpTotal;
            switch (_graveBot.CurrentClass)
            {
                case Classes.Zerg:
                    Game.Entities.Add(new Zerg(Map));
                    break;
                case Classes.Harpy:
                    Game.Entities.Add(new Harpy(Map));
                    break;
                case Classes.Roflcopter:
                    Game.Entities.Add(new Roflcopter(Map));
                    break;
                case Classes.Necromancer:
                    Game.Entities.Add(new Necromancer(Map));
                    break;
            }
            Game.Entities[Game.Entities.Count - 1] = _graveBot;
        }
    }
}