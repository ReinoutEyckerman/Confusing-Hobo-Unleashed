using System;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoundingBox
    {
        protected readonly int height;
        protected readonly int width;
        protected Position position;

        public BoundingBox(BoundingBox copy)
        {
            if (copy.position != null) position = new Position(copy.position);

            width = copy.width;
            height = copy.height;
        }

        public BoundingBox(Position position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public BoundingBox(int width, int height) //TODO legitness nakijken
        {
            position = null;
            this.width = width;
            this.height = height;
        }

        public Position getGeometricCenter()
        {
            return new Position(width / 2, height / 2);
        }

        public Position getPositionalCenter()
        {
            if (position == null) throw new NullReferenceException();

            return new Position(position.x + width / 2, position.y + height / 2);
        }

        public Position getPosition()
        {
            if (position == null) throw new NullReferenceException();
            return position;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public bool isPointInside(Position position)
        {
            return isPointInside(position.x, position.y);
        }

        public bool isPointInside(int x, int y)
        {
            if (x < getPosition().x) return false;

            if (y < getPosition().y) return false;

            if (x > getPosition().x + width) return false;

            if (y > getPosition().y + height) return false;

            return true;
        }

        public BoundingBox reposition(int x, int y)
        {
            return reposition(new Position(x, y));
        }

        public BoundingBox reposition(Position newPosition)
        {
            return new BoundingBox(newPosition, width, height);
        }

        public BoundingBox enlarge(int width, int height)
        {
            return new BoundingBox(position, this.width + width, this.height + height);
        }

        public BoundingBox grow(BoundingBox boundingBox)
        {
            var minX = Math.Min(position.x, boundingBox.position.x);
            var minY = Math.Min(position.y, boundingBox.position.y);
            var maxX = Math.Max(position.x + width, boundingBox.position.x + boundingBox.width);
            var maxY = Math.Max(position.y + height, boundingBox.position.y + boundingBox.height);
            return new BoundingBox(new Position(minX, minY), maxX - minX, maxY - minY);
        }

        public BoundingBox grow(int padding)
        {
            return new BoundingBox(new Position(position.x - padding, position.y - padding), width + padding,
                height + padding);
        }
    }
}