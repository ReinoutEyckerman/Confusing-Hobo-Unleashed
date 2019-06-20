using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Position
    {
        public int x;
        public int y;

        public Position(Position copy)
        {
            this.x = copy.x;
            this.y = copy.y;
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public Position add(Position position)
        {
            int x = this.x + position.x;
            int y = this.y + position.y;
            return new Position(x, y);
        }

        public Position substract(Position position)
        {
            int x = this.x - position.x;
            int y = this.y - position.y;
            return new Position(x, y);
        }

        public static Position getMinPosition(Position a, Position b)
        {
            return new Position(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        public static Position getMaxPosition(Position a, Position b)
        {
            return new Position(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
        }

        public Orientation orientationTo(Position position)
        {
            if (Math.Abs(x - position.x) > Math.Abs(y - position.y))
            {
                if (x < position.x)
                {
                    return Orientation.East;
                }
                else
                {
                    return Orientation.West;
                }
            }
            else
            {
                if (y < position.y)
                {
                    return Orientation.South;
                }
                else
                {
                    return Orientation.North;
                }
            }
        }
    }
}