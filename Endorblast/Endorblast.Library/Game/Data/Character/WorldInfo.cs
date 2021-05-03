using Microsoft.Xna.Framework;

namespace Endorblast.Lib.Game.Utils
{
    public class WorldInfo
    {
        private int worldID;
        private Vector2 position;
        
        
        public int WorldID
        {
            get => worldID;
            set => worldID = value;
        }
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }


        public WorldInfo()
        { }
        
        public WorldInfo(int worldId, Vector2 position)
        {
            WorldID = worldId;
            Position = position;
        }

        public WorldInfo(int worldId,float x, float y) : this(worldId, new Vector2(x, y))
        { }
        
        
    }
}