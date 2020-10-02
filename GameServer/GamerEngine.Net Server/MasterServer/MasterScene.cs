using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Tiled;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MasterServer
{
    class MasterScene
    {

        public static TmxMap tiledMap;

        public static TmxObject spawnPoint;
        public static TmxLayer tiledLayer;


        public static void Init(string path)
        {



            Core.Scene = Scene.CreateWithDefaultRenderer(Color.CornflowerBlue);

            Core.Scene.Camera.AddComponent<MouseScript>();

            UIManager.Init();
            

            tiledMap = Core.Scene.Content.LoadTiledMap(path);
            var objectLayers = tiledMap.GetObjectGroup("PlayerSpawns");

            for (int i = 0; i < objectLayers.Objects.Count; i++)
            {
                if (objectLayers.Objects[i].Name == "PlayerSpawn1")
                {
                    spawnPoint = objectLayers.Objects[i];
                }
            }

            tiledLayer = tiledMap.GetLayer<TmxLayer>("Ground");

            var tiledEntity = Core.Scene.CreateEntity("tiled-map");
            var tiledMapComponet = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap));

        }

    }
}
