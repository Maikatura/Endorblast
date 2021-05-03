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
using Endorblast.Library.Enums;
using Endorblast.Library.GameObjects;

namespace Endorblast.Library
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
            string path = "";

            switch (type)
            {
                case MapType.LoginMap:
                    path = "/Data/Maps/Town.tmx";
                    break;
                case MapType.Snowlands:
                    path = "/Data/Maps/Snowland.tmx";
                    break;
                case MapType.Town:
                    path = "/Data/Maps/Town.tmx";
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

            for (int i = 0; i < map.ObjectGroups.Count; i++)
            {
                for (int j = 0; j < map.ObjectGroups[i].Objects.Count; j++)
                {
                    if (map.ObjectGroups[i].Objects[j].Name.ToUpper() == "grass".ToUpper())
                    {
                        float x = map.ObjectGroups[i].Objects[j].X;
                        float y = map.ObjectGroups[i].Objects[j].Y;
                        Grass grass = new Grass();
                        grass.SetPosition(x, y);

                        Console.WriteLine("Grass found!");
                        
                        scene.AddEntity(grass);
                    }
                }
            }
        }
        

        public static Vector2 Center => new Vector2((map.Width) / 2, (map.Height) / 2);


    }
}
