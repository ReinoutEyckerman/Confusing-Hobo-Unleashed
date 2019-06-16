using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Graphics.Image
{
    public class Image : BoundingBox, Drawable
    {
        private readonly Pixel[,] imageGrid;
        private Window window; 

        public Image(Pixel[,] imageGrid, Window window) : base(new Position(0,0), imageGrid.GetLength(0),
            imageGrid.GetLength(1)) //TODO new pos
        {
            this.imageGrid = imageGrid;
            this.window = window;
        }
        public Image(Pixel[,] imageGrid, Position position, Window window) : base(position, imageGrid.GetLength(0),
            imageGrid.GetLength(1)) //TODO new pos
        {
            this.imageGrid = imageGrid;
            this.window = window;
        }

        public void Draw()
        {
            for (var i = 0; i < getWidth(); i++)
            for (var j = 0; j < getHeight(); j++)
                if (imageGrid[i, j] != null)
                    window.Draw(position.add(new Position(i, j)), imageGrid[i, j]);
        }

        public void DrawRelative(Position relativeTo)
        {
            var relativePosition = position.add(relativeTo);
            for (var i = 0; i < getWidth(); i++)
            for (var j = 0; j < getHeight(); j++)
                if (imageGrid[i, j] != null)
                    window.Draw(relativePosition.add(new Position(i, j)), imageGrid[i, j]);
        }

        public Image addTopLayer(GeneratedImage image)
        {
            return addTopLayer(image.toImage());
        }

        public Image addTopLayer(Image topLayer)
        {
            var topLeft = Position.getMinPosition(position, topLayer.position);
            var bottomRight = Position.getMaxPosition(position.add(new Position(getWidth(), getHeight())),
                topLayer.position.add(new Position(topLayer.getWidth(), topLayer.getHeight())));
            var dimensions = bottomRight.substract(topLeft);
            var width = dimensions.x;
            var height = dimensions.y;
            var imagegrid = new Pixel[width, height];

            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                var pixel = new Pixel();

                var currentPosition = topLeft.add(new Position(i, j));
                if (isPointInside(currentPosition)) pixel.add(imageGrid[i, j]);

                if (topLayer.isPointInside(currentPosition)) pixel.add(topLayer.imageGrid[i, j]);

                imagegrid[i, j] = pixel;
            }

            return AbstractUIFactory.getInstance().buildImage(imagegrid, topLeft);
        }

        public Pixel[,] ImageGrid => imageGrid;
    }
}