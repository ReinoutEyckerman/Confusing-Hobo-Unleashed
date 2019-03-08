using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confusing_Hobo_Unleashed.UI
{
    class Rectangle 
    {
        public Position topleft { get; }
        public Position bottomright { get; }

        public Rectangle(Position topleft, Position bottomright)
        {
            this.topleft = topleft;
            this.bottomright = bottomright;
        }
           
        public void setTopX(int x)
        {
            this.topleft.setX(x);
        }

        public void setBottomX(int x)
        {
            this.bottomright.setX(x);
        }

        public void setLeftY(int y)
        {
            this.topleft.setY(y);
        }

        public void setRightY(int y)
        {
            this.bottomright.setX(y);
        }

    }
}