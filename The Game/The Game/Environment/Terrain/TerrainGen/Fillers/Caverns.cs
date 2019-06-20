using System;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Caverns
    {
        public Entity[,] Cavern(Orientation orientation, int width, int height, int holeStartHeight, int holeEndHeight, int startY, int endY)
        {
            Entity[,] g1 = Line.fillLine(orientation, null, width, height, startY, endY);
            Entity[,] g2 = Line.fillLine(orientation.Next().Next(), null, width, height, startY + holeStartHeight, endY + holeEndHeight);
            return Glue.glue(g2, g1, orientation, 0);
        }

        public Entity[,] DeadEnd(Orientation orientation, int width, int height, int holeStartWidth, int holeEndWidth, int startX, int endX, int holeDepth)//TODO rename
        {
            Entity[,] grid = Cavern(orientation, holeDepth, height, holeStartWidth, holeEndWidth, startX, endX);
            Entity[,] filling = Line.fillLine(orientation.Next(), null, width, height, holeDepth, holeDepth);//TODO review
            return Glue.glue(grid, filling, orientation, holeDepth);
        }

        public Entity[,] TCavern(Orientation orientation, int width, int height, int holeStartWidth, int holeEndWidth, int holeBottomWidth, int startX, int endX, int bottomX)
        {
            Entity[,] hatTop = Line.fillLine(orientation, null, width, height, startX, endX);
            Entity[,] hatBottom = Line.fillLine(orientation.Next().Next(), null, width, height, startX + holeStartWidth, endX+ holeEndWidth);
            Entity[,] Leg = Cavern(orientation.Next(), width, height, holeStartWidth, holeEndWidth, startX, endX);
            return Glue.glue(hatTop, Glue.crack(hatBottom, Leg, Orientation.South, 0), Orientation.South, 0);
        }

        public Entity[,] LCavern(Orientation orientation, int width, int height, int holeStartWidth, int holeEndWidth, int holeBottomWidth, int startX, int endX, int bottomX)
        {
            throw  new NotImplementedException();
        }

        public Entity[,] XCavern(Orientation orientation, int width, int height, int holeStartWidth, int holeEndWidth, int holeBottomWidth, int startX, int endX, int bottomX)
        {
            throw  new NotImplementedException();
        }
        
    }
}