using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Block : Entity, Drawable
    {
        private readonly Pixel pixel;

        public Block(Block copy) : base(copy)
        {
            pixel = copy.pixel;
        }

        protected Block(Pixel pixel, int maxHp, BoundingBox bounds, bool invincible = false) : base(maxHp, bounds,
            invincible)
        {
            this.pixel = pixel;
        }

        public void Draw()
        {
            for (int i = 0; i < bounds.getWidth(); i++)
            for (int j = 0; j < bounds.getHeight(); j++)
                window.Draw(bounds.getPosition().add(new Position(i, j)), pixel);
        }

        public void DrawRelative(Position relativeTo)
        {
            for (int i = 0; i < bounds.getWidth(); i++)
            for (int j = 0; j < bounds.getHeight(); j++)
                window.Draw(relativeTo.add(bounds.getPosition().add(new Position(i, j))), pixel);
        }

        protected override void Damage()
        {
            throw new NotImplementedException();
        }
    }
}