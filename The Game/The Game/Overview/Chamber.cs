using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Chamber:Drawable
    {
        private Position _position;

        public bool northOpen { get;private set;  }
        public bool eastOpen{ get; private set; }
        public bool southOpen{ get;private set;  }
        public bool westOpen{ get; private set; }

        public Chamber(Position position)
        {
            this._position = position;
        }


        public void Draw()//TODO
        {
            throw new System.NotImplementedException();
        }

        public bool IsDiscovered { get; private set; }

        public Position getPosition()
        {
            return _position;
        }

        public void setDiscovered()
        {
            this.IsDiscovered = true;
        }

        public void resetWalls()
        {
            northOpen = false;
            eastOpen = false;
            southOpen = false;
            westOpen = false;
        }

        public void unlockWall(Position position)
        {
            
        }
    }
}