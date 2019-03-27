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
    }
}