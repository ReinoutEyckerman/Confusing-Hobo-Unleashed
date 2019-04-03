using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Bounding
    {
        protected Position position;
        protected int width;
        protected int height;

        public Bounding(Bounding copy)
        {
            if (copy.position != null)
            {
                this.position = new Position(copy.position);
            }

            this.width = copy.width;
            this.height = copy.height;
        }

        public Bounding(Position position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public Bounding(int width, int height)
        {
            this.position = null;
            this.width = width;
            this.height = height;
        }

        public Position getGeometricCenter()
        {
            return new Position(this.width / 2, this.height / 2);
        }

        public Position getPositionalCenter()
        {
            if (position == null)
            {
                throw new NullReferenceException();
            }

            return new Position(this.position.x + this.width / 2, this.position.y + this.height / 2);
        }

        public Position getPosition()
        {
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
            if (position.x < this.position.x)
            {
                return false;
            }

            if (position.y < this.position.y)
            {
                return false;
            }

            if (position.x > this.position.x + this.width)
            {
                return false;
            }

            if (position.y > this.position.y + this.height)
            {
                return false;
            }

            return true;
        }
    }
}