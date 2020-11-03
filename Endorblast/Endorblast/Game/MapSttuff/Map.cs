using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;

namespace Endorblast
{
    public class Map
    {
        public const int TileSize = 32;

        public int Width;
        public int Height;
        TmxMap map;
        


        public Vector2 Center => new Vector2((map.Width * TileSize) / 2, (map.Height * TileSize) / 2);

        public void LoadMap()
        {
            var tiledMap = TiledMapsContent.gameTiledmap;
            var objectLayers = tiledMap.GetObjectGroup("PlayerSpawns");

            for (int i = 0; i < objectLayers.Objects.Count; i++)
            {
                if (objectLayers.Objects[i].Name == "PlayerSpawn1")
                {
                    //playerSpawn = objectLayers.Objects[i];
                }
            }

            //groundLayer = tiledMap.GetLayer<TmxLayer>("Ground");


            var tiledEntity = Core.Scene.CreateEntity("tiled-map");

            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap));
            tiledMapComponent.SetRenderLayer(100);
        }
    }

}
