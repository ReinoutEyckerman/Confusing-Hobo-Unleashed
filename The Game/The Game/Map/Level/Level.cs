using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Level:Drawable 
    {
        private Terrain terrain;
        private List<Entity> entities;
        private Entity player;
        private GameUi gameUi;
        
        public void Draw()
        {
            this.terrain.Draw();
            this.gameUi.Draw();
            foreach (Entity entity in this.entities)
            {
                entity.Draw();
            }
        }
    }
}