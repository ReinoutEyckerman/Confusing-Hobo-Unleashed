using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes.Animations;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class Fire : Animation
    {
        private FireFrameGenerator _generator;
        private int frameDuration;

        public Fire(Pixel pixel,BoundingBox bounds, int updateSpeed)
        {
            frameDuration = 1 / updateSpeed;//TODO
            _generator = new FireFrameGenerator(pixel,bounds);
        }

        public override void Draw()
        {
            Frame frame = new Frame(_generator.toImage(), frameDuration);
            base.addFrame(frame);
            base.Draw();
        }
        public override void DrawRelative(Position position)
        {
            Frame frame = new Frame(_generator.toImage(), frameDuration);
            base.addFrame(frame);
            base.DrawRelative(position);
        }
    }
}