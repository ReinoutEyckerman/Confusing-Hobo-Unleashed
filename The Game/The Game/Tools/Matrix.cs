using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Tools
{
    public class Matrix<T>
    {
        private T[,] matrix;
        private int width;
        private int height;
        private Orientation orientation;

        public Matrix(int width, int height)
        {
            matrix = new T[width, height];
            this.width = width;
            this.height = height;
        }

        public void put(int x, int y, T item)
        {
            if (x >= width || x < 0)
                return; //TODO Error
            if (y >= height || y < 0)
                return;
            matrix[x, y] = item;
        }

        public T get(int x, int y)
        {
            /*
            if (x >= width || x < 0)
                return; //TODO Error
            if (y >= height || y < 0)
                return;
                */
            return matrix[x, y];
        }

        public void Rotate90d()
        {
        }

        private Position transform(Position position)//TODO remove position
        {
            int x;
            int y;
            switch (orientation)
            {
                case Orientation.North:
                    return position;
                case Orientation.South:
                    position.setX(width - position.getX());
                    position.setY(height - position.getY());
                    return position;
                case Orientation.East:
                    x = height - position.getY();
                    y = position.getX();
                    position.setX(x);
                    position.setY(y);
                    return position;
                case Orientation.West:
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