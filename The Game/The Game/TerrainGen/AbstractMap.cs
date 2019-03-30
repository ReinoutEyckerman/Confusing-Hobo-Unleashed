using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public abstract class AbstractMap:Drawable
    {
        private GravField gravField;
        private Scenery scenery;
        private Terrain terrain;

        public AbstractMap(GravField gravField, Scenery scenery, Terrain terrain)
        {
            this.gravField = gravField;
            this.scenery = scenery;
            this.terrain = terrain;
        }
            

        public void Draw()
        {
            scenery.Draw();
            terrain.Draw();
        }
    }
}