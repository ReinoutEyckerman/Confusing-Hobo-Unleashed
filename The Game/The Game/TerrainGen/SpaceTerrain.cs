using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class SpaceTerrain

    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 1;
        public static void Redirect(int selected)
        {
            Game.CurrentLoadedMap.DayNightEnabled = true;
            Game.CurrentLoadedMap.CloudsEnabled = true;
            switch (selected)
            {
                case 0:
                    AsteroidField();
                    break;
            }
        }

        private static void AsteroidField()
        {
            for (int xwall = 0; xwall < Console.WindowWidth; xwall++)
            {
                for (int ywall = 0; ywall <= Game.CurrentLoadedMap.Mapheight - 1; ywall++)
                {
                    if (Random.Next(12) == 7)
                    {
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Background[ywall, xwall] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
                        Game.CurrentLoadedMap.Collision[ywall, xwall] = true;
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[ywall, xwall] = ' ';
                    }
                }
            }
        }
    }
}