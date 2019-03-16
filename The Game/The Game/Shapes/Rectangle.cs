using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Rectangle 
    {
        public Position position { get; }
        private int width;
        private int height;

        public Rectangle(Position position,int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public Position getGeometricCenter()
        {
            return new Position( this.width / 2, this.height / 2);
        }
        
        public Position getPositionalCenter()
        {
            return new Position(this.position.x + this.width / 2, this.position.y + this.height / 2);
        }
        
        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }
    }
}