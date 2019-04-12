using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class SmallCloud : ComplexShape
    {
        protected static Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        protected static Pixel c = new Pixel(BaseColor.White, BaseColor.White, ' ');
        
        private static Pixel[,] cloud =
        {
            {v, v, c, v, v, v, v, v, v, v, v},
            {v, c, c, c, c, c, c, c, c, v, v},
            {c, c, c, c, c, c, c, c, c, c, c},
            {c, c, c, c, c, c, v, v, v, v, v}
        };

        public SmallCloud(ShapeDecorator copy) : base(copy)
        {
        }

        public SmallCloud(Shape decoratedShape, Window window, Position position) : base(decoratedShape, cloud, window, position)
        {
            
        }

        public override Shape Clone()
        {
            return new SmallCloud(this);
        }
    }
}