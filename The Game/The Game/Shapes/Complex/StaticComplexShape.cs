using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    //TODO: Perfect use case for complex shapes
    public abstract class ComplexShape : ShapeDecorator
    {
        private readonly Pixel[,] pixelGrid;

        protected ComplexShape(ShapeDecorator copy) : base(copy)
        {
        }

        protected ComplexShape(Shape decoratedShape, Pixel[,] pixelGrid, Window window, Position position) : base(decoratedShape, pixelGrid[0, 0], window, position, pixelGrid.GetLength(0), pixelGrid.GetLength(1))
        {
            this.pixelGrid = pixelGrid;
        }

        public override Image toImage()
        {
            return base.toImage().addTopLayer(new Image(this.pixelGrid, this.position));
        }
    }
}