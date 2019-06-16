using System;
using Confusing_Hobo_Unleashed.Geometry;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class TerrainGenerationModules //TODO: Wiskundige formules, implementeer naar < /\ > \/
    {
        public static bool[,] convexEllipsOutside(bool[,] terrain, int centerY, bool topDown)
        {
            int width = terrain.GetLength(0);
            int height = terrain.GetLength(1) - centerY;

            RegularEllipse ellipse = new RegularEllipse(new Position(0, 0), width, height);

            for (int borderX = 0; borderX < width; borderX++)
            {
                for (int borderY = 0; borderY < height; borderY++) //TODO Coordinatenstelsels nakijken
                {
                    if (!ellipse.IsInsideShape(borderX, borderY)) ;
                    {
                        if (topDown && ellipse.IsInsideShape(borderX, borderY + 1))
                        {
                            for (int y = borderY; y >= 0; y--)
                            {
                                terrain[borderX, borderY] = true;
                            }

                            break;
                        }
                        else if (!topDown && ellipse.IsInsideShape(borderX, borderY - 1))
                        {
                            for (int y = borderY; y <= height - 1; y++)
                            {
                                terrain[borderX, borderY] = true;
                            }

                            break;
                        }
                    }
                }
            }
        }

        public static bool[,] convexEllipsInside(bool[,] terrain, int centerY)
        {
            int width = terrain.GetLength(0);
            int height = terrain.GetLength(1) - centerY;

            RegularEllipse ellipse = new RegularEllipse(new Position(0, 0), width, height);

            for (int borderX = 0; borderX < width; borderX++)
            {
                for (int borderY = 0; borderY < height; borderY++) //TODO Coordinatenstelsels nakijken
                {
                    if (ellipse.IsInsideShape(borderX, borderY)) ;
                    {
                        terrain[borderX, borderY] = true;
                    }
                }
            }
        }
    }
}