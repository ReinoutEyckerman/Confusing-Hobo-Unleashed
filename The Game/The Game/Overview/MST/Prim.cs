using System;
using System.Collections;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.MST
{
    public class Prim
    {

        
        private bool[,] isVisited;
        
        private void Plan(Chamber[,] chambers)
        {
            int width = chambers.GetLength(0);
            int height = chambers.GetLength(1);
            isVisited= new bool[width, height];
            Random random = new Random();
            Chamber startPosition = chambers[random.Next(width), random.Next(height)];
            List<Wall> walls = getNeighbors(startPosition, chambers);
            
            while (walls.Count > 0)
            {
                int wallIndex = random.Next(walls.Count);
                Wall randomWall = walls[wallIndex];
                walls.Remove(randomWall);
                if (!(randomWall.getChamber1().IsDiscovered && randomWall.getChamber2().IsDiscovered))
                {
                     
                }
            }
        }

        private List<Wall> getNeighbors(Chamber chamber, Chamber[,] chambers)
        {
            List<Wall> walls = new List<Wall>();
            chamber.setDiscovered();
            int x = chamber.getPosition().x; 
            int y = chamber.getPosition().y; 
            if (x > 0 && !chamber.northOpen)
            {
                walls.Add(new Wall(chamber, chambers[x-1,y] ));
            }
            if (x < chambers.GetLength(0)-1 && !chamber.southOpen)
            {
                walls.Add(new Wall(chamber, chambers[x+1,y] ));
            }
            if (y > 0 && !chamber.westOpen)
            {
                walls.Add(new Wall(chamber, chambers[x,y-1] ));
            }
            if (y < chambers.GetLength(1)-1 && !chamber.eastOpen)
            {
                walls.Add(new Wall(chamber, chambers[x,y+1] ));
            }

            return walls;
        }

        private void clean(Chamber[,] chambers)
        {
            for (int x = 0; x < chambers.GetLength(0); x++)
            {
                for (int y = 0; y < chambers.GetLength(1); y++)
                {
                    chambers[x,y].resetWalls();
                }
            }
        }
    }
}