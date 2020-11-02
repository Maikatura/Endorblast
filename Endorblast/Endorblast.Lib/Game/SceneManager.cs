using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nez.PhysicsShapes;
using Nez.Sprites;
using Endorblast.Lib.Game.GameObjects.Enviorment;

namespace Endorblast.Lib
{
    class SceneManager
    {

        TiledMapRenderer renderer;
        static int TileSize = 32;
        public static TmxObject playerSpawn;
        public static TmxLayer groundLayer;
        static GaussianBlurPostProcessor test;
        static TmxMap map;
        public static TmxObject dummySpawn;

        public static void InitGameMap()
        {

            map = Endorblast.Lib.TiledMapsContent.gameTiledmap;
            var objectLayers = map.GetObjectGroup("PlayerSpawns");

            for (int i = 0; i < objectLayers.Objects.Count; i++)
            {
                if (objectLayers.Objects[i].Name == "PlayerSpawn1")
                {
                    playerSpawn = objectLayers.Objects[i];

                }
                else if (objectLayers.Objects[i].Name == "DummySpawn1")
                {
                    dummySpawn = objectLayers.Objects[i];
                }
                else if (objectLayers.Objects[i].Name == "FirePole")
                {
                    FirePole pole = new FirePole();
                    pole.Position = new Vector2(objectLayers.Objects[i].X, objectLayers.Objects[i].Y);
                    Core.Scene.AddEntity(pole);
                }
            }


            

            groundLayer = map.GetLayer<TmxLayer>("Ground");


            var tiledEntity = Core.Scene.CreateEntity("tiled-map");

            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(map));
            tiledMapComponent.SetRenderLayer(100);


        }


        public static void LoadLoginBG()
        {
            var tiledMap = Endorblast.Lib.TiledMapsContent.mainMenuTiledmap;
            var tiledEntity = Core.Scene.CreateEntity("tiled-map");
            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap));
        }

        public static Vector2 Center => new Vector2((map.Width) / 2, (map.Height) / 2);


    }
}
