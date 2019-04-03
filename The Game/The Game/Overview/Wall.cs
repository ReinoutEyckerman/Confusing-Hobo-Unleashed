using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed
{
    public class Wall
    {
        private Chamber chamber1;
        private Chamber chamber2;

        public Wall(Chamber chamber1, Chamber chamber2)
        {
            this.chamber1 = chamber1;
            this.chamber2 = chamber2;
        }

        public Chamber getChamber1()
        {
            return chamber1;
        }
        
        public Chamber getChamber2()
        {
            return chamber2;
        }

        public bool isChamberDiscovered()
        {
            return this.chamber1.IsDiscovered != this.chamber2.IsDiscovered;
        }

        public void deleteWall()
        {
            Orientation firstOrientation = this.chamber1.getPosition().orientationTo(this.chamber2.getPosition());
            this.chamber1.unlockWall(firstOrientation);
            Orientation secondOrientation = this.chamber2.getPosition().orientationTo(this.chamber1.getPosition());
            this.chamber2.unlockWall(firstOrientation);
        }

        public Chamber getUndiscoveredChamber()
        {
            if (!this.chamber1.IsDiscovered)
            {
                return this.chamber1;
            }
            else if (!this.chamber2.IsDiscovered)
            {
                return this.chamber2;
            }
            else
            {
                return null;//TODO
            }
        }
    }
}