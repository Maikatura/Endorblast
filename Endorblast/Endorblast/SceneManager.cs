using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Endorblast
{
    class SceneManager
    {

        TiledMapRenderer renderer;
        static int TileSize = 32;
        public static TmxObject playerSpawn;
        public static TmxLayer groundLayer;
        static GaussianBlurPostProcessor test;
        static TmxMap map;

        public static void InitGameMap()
        {

            map = TiledMapsContent.gameTiledmap;
            var objectLayers = map.GetObjectGroup("PlayerSpawns");

            for (int i = 0; i < objectLayers.Objects.Count; i++)
            {
                if (objectLayers.Objects[i].Name == "PlayerSpawn1")
                {
                    playerSpawn = objectLayers.Objects[i];
                }
            }

            groundLayer = map.GetLayer<TmxLayer>("Ground");


            var tiledEntity = Core.Scene.CreateEntity("tiled-map");

            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(map));
            tiledMapComponent.SetRenderLayer(100);


        }


        public static void LoadLoginBG()
        {
            var tiledMap = TiledMapsContent.mainMenuTiledmap;
            var tiledEntity = Core.Scene.CreateEntity("tiled-map");
            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap));
        }

        public static Vector2 Center => new Vector2((map.Width) / 2, (map.Height) / 2);


    }
}
