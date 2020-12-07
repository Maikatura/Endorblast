using EndorblastCore.Lib;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.Game.Network.Commands;
using EndorblastCore.Server.NetCommands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.DeferredLighting;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Server
{
    public class MapManager
    {
        static MapManager instance;
        public static MapManager Instance => instance;
        public static void NewInstance() { instance = new MapManager(); }

        public long Seed { get; set; }

        public Map map;

        CharacterManager cManager;

        public MapManager()
        {
            cManager = CharacterManager.Instance;
        }

        public void GenerateMap(long seed = 0)
        {
            if (seed == 0)
                Seed = (long)Time.TotalTime;
            else
                Seed = seed;
        }

        public void GenerateMap(int lobbyId, MapType type, long seed = 0)
        {

            map = new Map(lobbyId);

            
            switch (type)
            {
                case MapType.Town:

                    

                    var testEntity = Core.Scene.CreateEntity("TestTiledMap-Town");
                    map.tiledMap = Core.Content.LoadTiledMap("Content/Tilesets/GameArea/GameStart.tmx");
                    map.ground = map.tiledMap.GetLayer<TmxLayer>("Ground");
                    testEntity.AddComponent(new TiledMapRenderer(map.tiledMap)).SetRenderLayer(10);

                    var objectLayers = map.tiledMap.GetObjectGroup("PlayerSpawns");
                    for (int i = 0; i < objectLayers.Objects.Count; i++)
                    {
                        if (objectLayers.Objects[i].Name == "DummySpawn1")
                        {
                            map.testSpawn = objectLayers.Objects[i];
                            EnemyManager.Instance.SpawnEnemyOnPoint(new Microsoft.Xna.Framework.Vector2(map.testSpawn.X, map.testSpawn.Y));
                            
                        }
                    }



                    break;
                case MapType.Snowlands:
                    
                    var testEntity2 = Core.Scene.CreateEntity("TestTiledMap-Town");
                    map.tiledMap = Core.Content.LoadTiledMap("Content/Tilesets/GameArea/Snowlands.tmx");
                    map.ground = map.tiledMap.GetLayer<TmxLayer>("Ground");
                    testEntity2.AddComponent(new TiledMapRenderer(map.tiledMap)).SetRenderLayer(10);

                    var objectLayers2 = map.tiledMap.GetObjectGroup("PlayerSpawns");
                    for (int i = 0; i < objectLayers2.Objects.Count; i++)
                    {
                        if (objectLayers2.Objects[i].Name == "DummySpawn1")
                        {
                            map.testSpawn = objectLayers2.Objects[i];
                            EnemyManager.Instance.SpawnEnemyOnPoint(new Microsoft.Xna.Framework.Vector2(map.testSpawn.X, map.testSpawn.Y));
                            
                        }
                    }
                    
                    
                    break;
                case MapType.Fortnite:
                    break;
               
            }

            //WorldDataCommand.Send()
        }

        public void Update()
        {
            //cManager.Update();

        }

    }
}
