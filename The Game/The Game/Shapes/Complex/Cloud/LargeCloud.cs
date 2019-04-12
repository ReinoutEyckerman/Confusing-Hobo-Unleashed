using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class LargeCloud : ComplexShape
    {
            
        //TODO Recoloring
        private static Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        private static Pixel c = new Pixel(BaseColor.White, BaseColor.White, ' ');
        private static Pixel[,] cloud =
        {
            {v, v, v, c, c, c, c, c, v, v, v, v, v, v, v, v, v, v},
            {v, v, c, c, c, c, c, c, c, c, c, c, v, v, v, v, v, v},
            {c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c}, 
            {c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c, c}, 
            {v, v, c, c, c, c, c, c, c, c, c, c, v, v, v, v, v, v}
        };
        
        public LargeCloud(ShapeDecorator copy) : base(copy)
        {
        }

        public LargeCloud(Shape decoratedShape, Window window, Position position) : base(decoratedShape,cloud, window, position)
        {
        }
        

        public override Shape Clone()
        {
            return new LargeCloud(this);
        }
    }
}