using Endorblast.Lib.Game.Network.Commands;
using EndorblastServer.Server.NetCommands.World;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.Game.Map
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
                    testEntity.AddComponent(new TiledMapRenderer(map.tiledMap));

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
                    Console.WriteLine("Not Done");
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
