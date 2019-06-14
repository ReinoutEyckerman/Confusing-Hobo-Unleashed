using System.Collections.Generic;
using System.Linq;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Chamber : Drawable
    {
        private Position _position;

        private Dictionary<Orientation, bool> directions;

        public Chamber(Position position)
        {
            this._position = position;
            this.directions = new Dictionary<Orientation, bool>()
            {
                {Orientation.NORTH, false},
                {Orientation.EAST, false},
                {Orientation.SOUTH, false},
                {Orientation.WEST, false}
            };
        }


        public void Draw() //TODO
        {
            throw new System.NotImplementedException();
        }

        public void DrawRelative(Position relativeTo)
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
            foreach (Orientation key in this.directions.Keys.ToList())
            {
                this.directions[key] = false;
            }
        }

        public void unlockWall(Orientation orientation)
        {
            this.directions[orientation] = true;
        }

        public bool isCorridorUnlocked(Orientation orientation)
        {
            return this.directions[orientation];
        }
    }
}