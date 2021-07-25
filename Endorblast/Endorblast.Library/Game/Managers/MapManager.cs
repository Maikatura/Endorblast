using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
    public class MapManager
    {

        public static MapManager Instance;
        
        //TiledMapRenderer renderer;
        //static int TileSize = 32;
        public TmxObject playerSpawn;
        public TmxLayer groundLayer;
        //static GaussianBlurPostProcessor test;
        static TmxMap map;
        public TmxObject dummySpawn;

        private Entity tiledEntity;

        public void InitGameMap(Scene scene, MapType type)
        {
            if (Instance == null)
                Instance = this;
            
            
            string path = "";

            switch (type)
            {
                case MapType.Snowlands:
                    path = "/Data/Maps/Snowland.tmx";
                    break;
                case MapType.Town:
                    path = "/Data/Maps/Town.tmx";
                    break;
                case MapType.TownPrototype:
                    path = "/Data/Maps/TownProto.tmx";
                    break;
                default:
                    Console.WriteLine("### ERROR : Map type not found");
                    break;
            }

            TmxMap setMap = ContentLoader.LoadTiledMap(path);
            map = setMap;

            tiledEntity = scene.CreateEntity("tiled-map");
            tiledEntity.AddComponent(new TiledMapRenderer(setMap, "Ground")).SetRenderLayer((int)RenderLayers.Layer.ObjectLayer);

            var tileRenderer = tiledEntity.GetComponent<TiledMapRenderer>();
            
            var objectLayer = tileRenderer.TiledMap.GetObjectGroup("Objects");
            
            if (objectLayer != null)
            {
                Console.WriteLine($"Found ");
                var objectPoints = objectLayer.Objects;
                
                
                Console.WriteLine($"Found {objectPoints.Count} Objects! Placing now");
                for (int i = 0; i < objectPoints.Count; i++)
                {
                    Console.SetCursorPosition(Console.CursorLeft,  Console.CursorTop);

                    string objString = "";
                    
                    var objType = (ObjectTypes) Enum.Parse(typeof(ObjectTypes), objectPoints[i].Type, true);
                    float x = objectPoints[i].X;
                    float y = objectPoints[i].Y;
                    
                    
                    

                    switch (objType)
                    {
                        case ObjectTypes.TallGrass:
                            Grass grass = new Grass();
                            grass.SetPosition(x, y);
                            scene.AddEntity(grass);
                            objString = "Grass";
                            break;
                        case ObjectTypes.Portal:
                            break;
                        
                    }

                    Console.WriteLine($"{i + 1}/{objectPoints.Count} Placed {objString}");
                }
            }
            
            groundLayer = tileRenderer.CollisionLayer;
        }
        

        public Vector2 Center => new Vector2((map.Width) / 2, (map.Height) / 2);


    }
}
