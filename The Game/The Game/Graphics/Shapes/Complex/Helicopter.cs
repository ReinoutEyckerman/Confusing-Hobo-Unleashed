using System;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class Helicopter : GeneratedImage 
    {
        private static readonly ColorPoint voidPoint = new ColorPoint(BaseColor.Void, BaseColor.Void);
        private static readonly Pixel v = new Pixel(voidPoint, ' ');
        private static readonly Pixel R = new Pixel(voidPoint, 'R');
        private static readonly Pixel O = new Pixel(voidPoint, 'O');
        private static readonly Pixel F = new Pixel(voidPoint, 'F');
        private static readonly Pixel L = new Pixel(voidPoint, 'L');
        private static readonly Pixel d = new Pixel(voidPoint, ':');
        private static readonly Pixel h = new Pixel(voidPoint,'^');
        private static readonly Pixel a = new Pixel(voidPoint,'-');
        private static readonly Pixel e = new Pixel(voidPoint, '=');
        private static readonly Pixel s = new Pixel(voidPoint, '\\');
        private static readonly Pixel x = new Pixel(voidPoint, '[');
        private static readonly Pixel y = new Pixel(voidPoint, ']');
        private static readonly Pixel I = new Pixel(voidPoint, 'I');
        private static readonly Pixel u = new Pixel(voidPoint, '/');
        private static readonly Pixel w = new Pixel(voidPoint,'_');
        
        private Pixel[,] copter1 =
        {
            {R, O, F, L, d, R, O, F, L, d, L, O, L, v, v, v},
            {v, v, v, v, v, v, v, v, v, v, v, h, v, v, v, v},
            {v, v, v, v, v, v, u,a, a, a, a, a, a, a, v, v},
            {v, L, O, L, e, e, e, v, v, v, v, v, x, y, s, v},
            {v, v, v, v, v, v, v, s, v, v, v, v, v, v, v, s},
            {v, v, v, v, v, v, v, s, w, w, w, w, w, w, w, y},
            {v, v, v, v, v, v, v, v, I, v, v, v, v, I, v, v},
            {v, v, v, v, v, v, v, a, a, a, a, a, a, a, a,u}
        };

        private Pixel[,] copter2 =
        {
            { v, v, v, v, v, v, v, v, v, v, L, O, L, R, O, F, L, d, R, O, F, L },
            { v, v, v, v, v, v, v, v, v, v, v, h, v, v, v, v, v, v, v, v, v, v }, 
            { v, v, L, v, v, v, u, a, a, a, a, a, a, a, v, v, v, v, v, v, v, v },
            { v, v, O, v, e, e, e, v, v, v, v, v, x, y, s, v, v, v, v, v, v, v },
            { v, v, L, v, v, v, v, s, v, v, v, v, v, v, v, s, v, v, v, v, v, v },
            { v, v, v, v, v, v, v, s, w, w, w, w, w, w, w, y, v, v, v, v, v, v },
            { v, v, v, v, v, v, v, v, I, v, v, v, v, I, v, v, v, v, v, v, v, v },
            { v, v, v, v, v, v, v, a, a, a, a, a, a, a, a, u, v, v, v, v, v, v }
        };

        public Image toImage()
        {
            throw new NotImplementedException();
        }
    }
}