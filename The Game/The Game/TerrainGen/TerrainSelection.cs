using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    

    internal class TerrainSelection
    {
        public static void RoomDistribution()
        {
            int multiplier = 0;
            int multiplier2 = 0;
            int roomAmount = 0;
            int roomAmount2 = 0;
            switch (VarDatabase.CurrentLayer)
            {
                case MapLayers.Space:
                    multiplier = 0;
                    roomAmount = SpaceTerrain.MapAmount;
                    break;
                case MapLayers.Sky:
                    multiplier = 100;
                    roomAmount = SkyTerrain.MapAmount;
                    break;
                case MapLayers.Earth:
                    multiplier = 200;
                    multiplier2 = 300;
                    roomAmount = LandTerrain.MapAmount;
                    roomAmount2 = SeaTerrain.MapAmount;
                    break;
                case MapLayers.Cave:
                    multiplier = 400;
                    roomAmount = CaveTerrain.MapAmount;
                    break;
            }
            MapGeneration.Terrains = new int[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical];
            var random = new Random();
            for (int x = 0; x < MapGeneration.RoomsHorizontal; x++)
            {
                for (int y = 0; y < MapGeneration.RoomsVertical; y++)
                {
                    int usedMultiplier = multiplier;
                    int usedRoomAmount = roomAmount;
                    if (roomAmount2 != 0)
                    {
                        if (random.Next(2) == 0)
                        {
                            usedMultiplier = multiplier2;
                            usedRoomAmount = roomAmount2;
                        }
                    }
                    if (MapGeneration.Counter[x, y, 4])
                    {
                        MapGeneration.Terrains[x, y] = usedMultiplier + random.Next(usedRoomAmount);
                    }
                }
            }
        }

        public static void Redirect(CustomMap map, int selector)
        {
            switch (selector/100)
            {
                case 0:
                    if (selector%100 <= SpaceTerrain.MapAmount - 1)
                        SpaceTerrain.Redirect(selector%10);
                    break;
                case 1:
                    if (selector%100 <= SkyTerrain.MapAmount - 1)
                        SkyTerrain.Redirect(map, selector%10);
                    break;
                case 2:
                    if (selector%100 <= LandTerrain.MapAmount - 1)
                        LandTerrain.Redirect(map, selector%10);
                    break;
                case 3:
                    if (selector%100 <= SeaTerrain.MapAmount - 1)
                        SeaTerrain.Redirect(map, selector%10);
                    break;
                case 4:
                    if (selector%100 <= CaveTerrain.MapAmount - 1)
                        CaveTerrain.Redirect(map, selector%10);
                    break;
                case 5:
                    break;
            }
            TerrainGenerationModules.MakeDestructable(6);
        }
    }
}