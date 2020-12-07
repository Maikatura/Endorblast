using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Enums;
using Nez;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nez.PhysicsShapes;
using Nez.Sprites;
using EndorblastCore.Lib.GameObjects;

namespace EndorblastCore.Lib
{
    class SceneManager
    {

        //TiledMapRenderer renderer;
        //static int TileSize = 32;
        public static TmxObject playerSpawn;
        public static TmxLayer groundLayer;
        //static GaussianBlurPostProcessor test;
        static TmxMap map;
        public static TmxObject dummySpawn;

        private static Entity tiledEntity;

        public static void InitGameMap(Scene scene, MapType type)
        {

            

            //var objectLayers = map.GetObjectGroup("PlayerSpawns");

            //for (int i = 0; i < objectLayers.Objects.Count; i++)
            //{
            //    if (objectLayers.Objects[i].Name == "PlayerSpawn1")
            //    {
            //        playerSpawn = objectLayers.Objects[i];

            //    }
            //    else if (objectLayers.Objects[i].Name == "DummySpawn1")
            //    {
            //        dummySpawn = objectLayers.Objects[i];

            //        Entity dummyThing = new Entity("DummyThingToTestWith");
            //        dummyThing.SetPosition(dummySpawn.X, dummySpawn.Y);
            //        var lol = dummyThing.AddComponent(new Skeleton());


            //        Core.Scene.AddEntity(dummyThing);
            //    }
            //    else if (objectLayers.Objects[i].Name == "FirePole")
            //    {
            //        FirePole pole = new FirePole();
            //        pole.Position = new Vector2(objectLayers.Objects[i].X, objectLayers.Objects[i].Y);
            //        scene.AddEntity(pole);
            //    }

            //    if (objectLayers.Objects[i].Name.Contains("Portal"))
            //    {
            //        string[] portalString = objectLayers.Objects[i].Name.Split('|');

            //        Portal portal = new Portal(int.Parse(portalString[1]));
            //        portal.Position = new Vector2(objectLayers.Objects[i].X, objectLayers.Objects[i].Y);
            //        scene.AddEntity(portal);
            //    }
            //}


            

            string path = "";

            switch (type)
            {
                case MapType.Snowlands:
                    path = "/Tilesets/GameArea/Snowlands.tmx";
                    break;
                case MapType.Town:
                    path = "/Tilesets/GameArea/GameStart.tmx";
                    break;
                default:
                    Console.WriteLine("### ERROR : Map type not found");
                    break;
            }

            TmxMap setMap = ContentLoader.LoadTiledMap(path);
            map = setMap;
            groundLayer = setMap.GetLayer<TmxLayer>("Ground");

            if (tiledEntity != null)
            {
                if (tiledEntity.HasComponent<TiledMapRenderer>())
                {
                    tiledEntity.GetComponent<TiledMapRenderer>().TiledMap = setMap;
                }
                else
                {
                    tiledEntity.AddComponent(new TiledMapRenderer(setMap)).SetRenderLayer(RenderLayers.ObjectLayer);
                }
            }
            else
            {
                tiledEntity = scene.CreateEntity("tiled-map");
                tiledEntity.AddComponent(new TiledMapRenderer(setMap)).SetRenderLayer(RenderLayers.ObjectLayer);
            }




        }


        public static void LoadLoginBG(Scene scene)
        {
            var tiledMap = EndorblastCore.Lib.TiledMapsContent.mainMenuTiledmap;
            var tiledEntity = scene.CreateEntity("tiled-map");
            var tiledMapComponent = tiledEntity.AddComponent(new TiledMapRenderer(tiledMap)).SetRenderLayer(RenderLayers.ObjectLayer);
        }

        public static Vector2 Center => new Vector2((map.Width) / 2, (map.Height) / 2);


    }
}
