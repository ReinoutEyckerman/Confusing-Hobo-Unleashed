using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new Position(x,y);
            
        }
    }
}