using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Position
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }
    }
}
