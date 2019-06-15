using System;
using System.Collections.Generic;
using System.Linq;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes.Animations
{
    public class Animation : Drawable
    {
        private int currentFrame;
        private int currentFrameRunTime;
        private readonly List<Frame> frames;

        public Animation()
        {
            frames = new List<Frame>();
        }

        public bool IsFinished { get; private set; }

        public void Draw()
        {
            if (!validFrame())
                return;
            updateRuntime();
            updateFrame();
            if (!validFrame())
            {
                IsFinished = true;
                return;
            }

            frames[currentFrame].Draw();
        }

        public void DrawRelative(Position relativeTo)
        {
            if (!validFrame())
                return;
            updateRuntime();
            updateFrame();
            if (!validFrame())
            {
                IsFinished = true;
                return;
            }

            frames[currentFrame].DrawRelative(relativeTo);
        }

        public void addFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public int getDuration()
        {
            return frames.Select(frame => frame.getDuration()).Sum();
        }

        private bool validFrame()
        {
            return currentFrame < frames.Count;
        }

        private void updateRuntime()
        {
            throw new NotImplementedException();
        }

        private void updateFrame()
        {
            if (frames[currentFrame].getDuration() >= currentFrameRunTime) currentFrame++;
        }
    }
}