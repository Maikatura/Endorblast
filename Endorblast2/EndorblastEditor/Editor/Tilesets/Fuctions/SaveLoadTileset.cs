using System;
using System.IO;
using System.Text;
using Endorblast.DB.Lib.TileMap;
using Newtonsoft.Json;

namespace Endorblast.DB.Lib.Game.TileMap.Tilesets.Fuctions
{
    public class SaveLoadTileset
    {

        
        
        public SaveLoadTileset()
        {
            var tileTest = new Tileset();
            
            
            SaveTile(tileTest, "file");
        }
        
        public void SaveTile(Tileset tileset, string fileName)
        {
            
            var json = JsonConvert.SerializeObject(tileset);
            Console.WriteLine(json);
        }


        public void LoadTileset(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                Console.WriteLine("Path is null");
                return;
            }
            
            byte[] fileBytes = File.ReadAllBytes(path);
            StringBuilder sb = new StringBuilder();
        }
    }
}