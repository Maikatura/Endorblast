using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace GamerEngineNet_Client
{
    class SceneManager
    {

        TiledMapRenderer renderer;

        public static TmxObject playerSpawn;
        public static TmxLayer groundLayer;


        public static void Init()
        {

            var tiledMap = Core.Content.LoadTiledMap("Content/Tilesets/MainMenu/MainMenu.tmx");
            var objectLayers = tiledMap.GetObjectGroup("PlayerSpawns");

            for (int i = 0; i < objectLayers.Objects.Count; i++)
            {
                if (objectLayers.Objects[i].Name == "PlayerSpawn1")
                {
                    playerSpawn = objectLayers.Objects[i];
                }
            }

            groundLayer = tiledMap.GetLayer<TmxLayer>("Ground");

            var tiledEntity = Core.Scene.CreateEntity("tiled-map");
            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap));

        }

    }
}
