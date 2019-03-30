using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public static  class OrientationTransformation
    {
        public static Position transform(Position position,int width, int height, Orientation orientation) //TODO remove position
        {
            int x;
            int y;
            switch (orientation)
            {
                case Orientation.NORTH:
                    return position;
                case Orientation.SOUTH:
                    position.setX(width - position.getX());
                    position.setY(height - position.getY());
                    return position;
                case Orientation.EAST:
                    x = height - position.getY();
                    y = position.getX();
                    position.setX(x);
                    position.setY(y);
                    return position;
                case Orientation.WEST:
                    x = position.getY();
                    y = width - position.getX();
                    position.setX(x);
                    position.setY(y);
                    return position;
            }
            return position;
        }
    }
}