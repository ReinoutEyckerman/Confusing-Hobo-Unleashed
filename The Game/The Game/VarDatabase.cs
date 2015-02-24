using Confusing_Hobo_Unleashed.TerrainGen;

namespace Confusing_Hobo_Unleashed
{
    public class VarDatabase
    {
        public const int FrameTimeMs = 40;
        public static int Invertrate = 1;
        public static Layers CurrentLayer = Layers.Earth;
        public static int SeaLevel = 30;
        public static int RoomAmount = 8;
        public static bool Day;
        //Debug Options
        public static bool Debug = false;
        public static bool ShowDeadEnd = false;
        public static bool ShowApprovementRate = false;
        public static bool ShowSideMatrix = false;
        public static bool ShowMapSizeDebug = false;
    }
}