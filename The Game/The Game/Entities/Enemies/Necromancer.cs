using System;
using System.Collections.Generic;
using System.Text;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;
using Confusing_Hobo_Unleashed.UI.Windows;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Necromancer : Updateable
    {
        private Updateable _entity;
        private static readonly int maxHp = 40;
        private static readonly int maxMana = 310;
        private static readonly int startMana = 0;

        private static readonly Pixel design = new Pixel(BaseColor.Green, BaseColor.Black,
            Encoding.GetEncoding(437).GetChars(new byte[] {127})[0]);

        private static readonly string weapon = "Iron Sword";
        private static readonly string spell = "Resurrect";

        private static readonly ShapedImage shape = new ShapedImage(
            AbstractUIFactory.getInstance().buildImage(new[,] {{design}}),
            new RegularRectangle(new Position(0, 0), 1, 1)); //TODO Fix this position problem!

        public Necromancer(Difficulty difficulty)
        {
            _entity = new RandomMovement(
                new DamageController(new SpellController(startMana, maxMana, new Entity(maxHp, shape))));
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}