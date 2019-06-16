using System;
using System.Collections.Generic;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public enum Layers
    {
        Space,
        Sky,
        Earth,
        Cave,
        Underworld
    }

    internal class TerrainSelection
    {
        private static TerrainGenerator terrain;
        private static readonly IDictionary<int, IDictionary<int, TerrainGenerator>> terrainDictionary = new Dictionary<int, IDictionary<int, TerrainGenerator>>
        {
            {
                0, new Dictionary<int, TerrainGenerator>
                {
                    {
                        0, SpaceTerrain.AsteroidField
                    }
                }
            },
            {
                1, new Dictionary<int, TerrainGenerator>
                {
                    {
                        0, SkyTerrain.Island
                    },
                    {
                        1, SkyTerrain.Islands
                    },
                    {
                        2, SkyTerrain.RandomIslands
                    },
                    {
                        3, SkyTerrain.Clouds
                    }
                }
            },
            {
                2, new Dictionary<int, TerrainGenerator>
                {
                    {
                        0, LandTerrain.Cliff
                    },
                    {
                        1, LandTerrain.Flat
                    },
                    {
                        2, LandTerrain.Forest
                    },
                    {
                        3, LandTerrain.HillSide
                    },
                    {
                        4, LandTerrain.HillSideInverted
                    },
                    {
                        5, LandTerrain.Mountain
                    },
                    {
                        6, LandTerrain.Valley
                    }
                }
            },
            {
                3, new Dictionary<int, TerrainGenerator>
                {
                    {
                        0, SeaTerrain.Beach
                    },
                    {
                        1, SeaTerrain.BeachInverted
                    },
                    {
                        2, SeaTerrain.Cliff
                    },
                    {
                        3, SeaTerrain.HillSide
                    },
                    {
                        4, SeaTerrain.HillSideInverted
                    },
                    {
                        5, SeaTerrain.Lake
                    },
                    {
                        6, SeaTerrain.Island
                    },
                    {
                        7, SeaTerrain.Sea
                    }
                }
            },
            {
                4, new Dictionary<int, TerrainGenerator>
                {
                    {
                        0, CaveTerrain.DeadEndEastCave
                    },
                    {
                        1, CaveTerrain.DeadEndNorthCave
                    },
                    {
                        2, CaveTerrain.DeadEndSouthCave
                    },
                    {
                        3, CaveTerrain.DeadEndWestCave
                    },
                    {
                        4, CaveTerrain.DownLeftQuarterCave
                    },
                    {
                        5, CaveTerrain.DownRightQuarterCave
                    },
                    {
                        6, CaveTerrain.HLineCave
                    },
                    {
                        7, CaveTerrain.InvertTCave
                    },
                    {
                        8, CaveTerrain.TCave
                    },
                    {
                        9, CaveTerrain.TLeftCave
                    },
                    {
                        10, CaveTerrain.TRightCave
                    },
                    {
                        11, CaveTerrain.UpLeftQuarterCave
                    },
                    {
                        12, CaveTerrain.UpRightQuarterCave
                    },
                    {
                        13, CaveTerrain.VLineCave
                    }
                }
            }
        };

        public static void RoomDistribution()
        {
            var multiplier = 0;
            var multiplier2 = 0;
            var roomAmount = 0;
            var roomAmount2 = 0;
            switch (VarDatabase.CurrentLayer)
            {
                case Layers.Space:
                    multiplier = 0;
                    roomAmount = SpaceTerrain.MapAmount;
                    break;
                case Layers.Sky:
                    multiplier = 100;
                    roomAmount = SkyTerrain.MapAmount;
                    break;
                case Layers.Earth:
                    multiplier = 200;
                    multiplier2 = 300;
                    roomAmount = LandTerrain.MapAmount;
                    roomAmount2 = SeaTerrain.MapAmount;
                    break;
                case Layers.Cave:
                    multiplier = 400;
                    roomAmount = CaveTerrain.MapAmount;
                    break;
            }
            MapGeneration.Terrains = new int[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical];
            var random = new Random();
            for (var x = 0; x < MapGeneration.RoomsHorizontal; x++)
            {
                for (var y = 0; y < MapGeneration.RoomsVertical; y++)
                {
                    var usedMultiplier = multiplier;
                    var usedRoomAmount = roomAmount;
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

        public static void Redirect(CustomMap map, int selector, bool invert = false)
        {
            if (map.Invertrate == 2 && !invert)
                Redirect(map, selector, true);
            terrainDictionary[selector/100][selector%10].Invoke(map, invert);
            TerrainGenerationModules.MakeDestructable(6);
        }

        private delegate void TerrainGenerator(CustomMap map, bool invert);
    }
}