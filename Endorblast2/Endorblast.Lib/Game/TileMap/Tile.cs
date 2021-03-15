using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Endorblast.DB.Lib.TileMap
{
    public class Tile
    {
        
        private bool[] tileRules = new bool[9];
        private List<Vector2> colliderPoints = new List<Vector2>();
        
        
        public int TilesetIndex { get; set; } = -1;
        
        public int TileIndex { get; set; } = -1;

        public void Draw(SpriteBatch spriteBatch, Vector2 tilePosition, int tileWidth, int tileHeight, List<Tileset> tilesets)
        {
            spriteBatch.DrawRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);

            if (TilesetIndex != -1 && TileIndex != -1)
            {
                Tileset tileset = tilesets[TilesetIndex];
                spriteBatch.Draw(tileset.Texture, tilePosition, tileset.Frames[TileIndex], Color.White);
            }
        }
    }
}