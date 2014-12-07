using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.TerrainGen;

namespace Confusing_Hobo_Unleashed.Map
{
    class MapGenerator
    {
        private delegate void TerrainDelegate;
        Dictionary<MapLayers, TerrainDelegate> terrain=new Dictionary<MapLayers, TerrainDelegate>{
            
        }; 
    }
}
