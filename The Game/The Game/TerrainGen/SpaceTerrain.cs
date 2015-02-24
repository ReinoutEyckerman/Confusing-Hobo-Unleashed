using System;
using Confusing_Hobo_Unleashed.Colors;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class SpaceTerrain

    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 1;

        public static void AsteroidField(CustomMap map, bool invert)
        {
            for (var xwall = 0; xwall < Console.WindowWidth; xwall++)
            {
                for (var ywall = 0; ywall <= Game.CurrentLoadedMap.Mapheight - 1; ywall++)
                {
                    if (Random.Next(12) == 7)
                    {
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Background[ywall, xwall] =
                            Painter.Instance.Paint(ConsoleColor.DarkRed);
                        Game.CurrentLoadedMap.Collision[ywall, xwall] = true;
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[ywall, xwall] = ' ';
                    }
                }
            }
        }
    }
}