using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.DB.Lib.TileMap
{
    public class TilemapHelper
    {
        private GraphicsDevice graphicsDevice;
        private string contentPath;

        public List<Tileset> Tilesets { get; private set; }

        public TilemapHelper(GraphicsDevice graphicsDevice, string contentPath)
        {
            this.graphicsDevice = graphicsDevice;
            this.contentPath = contentPath;
            SanitizeContentPath();
            LoadTilesets();
        }

        public void SaveTilesets()
        {
            for (int i = 0; i < Tilesets.Count; i++)
            {
                Tilesets[i].SaveToJson();
            }
        }

        private void SanitizeContentPath()
        {
            if (contentPath.LastIndexOf(@"\") != contentPath.Length - 1)
                contentPath += @"\";
        }

        private void LoadTilesets()
        {
            Tilesets = new List<Tileset>();

            string tilesetPath = contentPath + @"Tilesets\";
            List<string> jsonPaths = Directory.GetFiles(tilesetPath, "*.json").ToList();
            for (int i = 0; i < jsonPaths.Count; i++)
            {
                string jsonPath = jsonPaths[i];
                Tileset tileset = Tileset.FromJsonFile(jsonPath, graphicsDevice);
                Tilesets.Add(tileset);
            }
        }
        
        
    }
}