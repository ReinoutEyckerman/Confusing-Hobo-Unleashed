using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Enemy : Entity //TODO: Teams (of hostility)

    {
        protected Enemy(BoundingBox copy) : base(copy)
        {
        }

        protected Enemy(Position position, int width, int height) : base(position, width, height)
        {
        }

        protected Enemy(int width, int height) : base(width, height)
        {
        }
    }
}