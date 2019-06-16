using System;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Shapes.Complex;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Godzilla : Updateable
    {
        private Updateable _entity;
        private static readonly int maxHp = 5000;
        private static readonly string weapon = "touch";

        private static readonly ShapedImage shape = new ShapedImage(
            new GodzillaDrawing().toImage(),
            new RegularRectangle(new Position(0, 0), 1, 1)); //TODO Fix this position problem!

        public Godzilla(Difficulty difficulty)
        {
            _entity = new FlyingController(new DamageController(new Entity(maxHp, shape)));
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}