using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Chamber:Drawable
    {
        private Position _position;

        public Chamber(Position position)
        {
            this._position = position;
        }


        public void Draw()//TODO
        {
            throw new System.NotImplementedException();
        }

        public bool IsDiscovered { get; private set; }

        public void setDiscovered()
        {
            this.IsDiscovered = true;
        }
    }
}