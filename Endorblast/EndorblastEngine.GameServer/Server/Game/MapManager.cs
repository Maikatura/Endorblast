using System;
using System.Collections.Generic;
using System.Linq;
using Endorblast.DBase;
using Endorblast.GameServer.Entities;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Nez.Tiled;

namespace Endorblast.GameServer.Server
{
    public class MapManager
    {
        
        
        private static MapManager instance = new MapManager();
        public static MapManager Instance => instance;
        
        
        public List<Map> worlds = new List<Map>();
        private int worldId = 0;


        public MapManager()
        {
            
            
            
        }
        
        public void Update()
        {
            foreach (var map in worlds)
                map.Update();
        }

        public Map AddWorld(MapType type)
        {
            Console.WriteLine("Added a map with type: "+ type);
            
            var map = new Map(worldId, type);
            worlds.Add(map);
            worldId++;
            return map;
        }
        
        public void RemoveWorld(Map world)
        {
            worlds.Remove(world);
        }
        
        public void WorldSnapshot()
        {
            /* Todo : Make Snapshot of world.
             Here a snapshot of the world will be taken
             with all entities states and position. 
             If something isn't right take action against that
             entity.
             
             BAN THEM >:)
             
             */

        }


        public NetConnection GetPlayer(NetConnection con)
        {
            NetConnection player;
            foreach (var world in worlds)
            {
                player = world.characterManager.GetConnection(con);

                if (player != null)
                    return player;
            }

            return null;


            // Need to work on the login system :(
            
        }

        public List<NetConnection> GetPlayers(int worldId)
        {
            var list = new List<NetConnection>();
            
            foreach (var map in worlds)
                if (map.worldId == worldId)
                    list = map.characterManager.GetPlayers();
            
            return list;
            
        }
        
        public List<NetConnection> GetConnections(int worldId)
        {
            var list = new List<NetConnection>();
            
            foreach (var map in worlds)
                if (map.worldId == worldId)
                    foreach (var player in map.characterManager.Characters)
                        list.Add(player);
            
            return list;
            
        }

        public Map AddPlayer(NetConnection con, int charaID)
        {
            var playerLocation = new LoadCharacterLocationCmd().LoadLocation(charaID);

            var firstMap = worlds.Find(x => playerLocation.mapType == x.mapType);

            if (firstMap == null)
            {
                var map = AddWorld(playerLocation.mapType);
                map.AddPlayer(con);
                return map;
            }
            else
            {
                foreach (var map in worlds)
                {
                    if (map.mapType == playerLocation.mapType)
                    {
                        map.AddPlayer(con);
                        return map;
                    }
                }
            }
            

            return null;

        }

        // public Map RemovePlayer(int playerID)
        // {
        //     foreach (var map in worlds)
        //     {
        //         foreach (var player in map.characterManager.Characters)
        //         {
        //             if (player.playerID == playerID)
        //             {
        //                 map.characterManager.Characters.Remove(player);
        //                 return map;
        //             }
        //         }
        //     }
        //
        //     return null;
        // }
        
        public Map RemovePlayer(NetConnection con)
        {
            foreach (var map in worlds)
                if (map.worldId == worldId)
                    foreach (var player in map.characterManager.Characters)
                        if (player == con)
                            map.characterManager.Characters.Remove(player);

            return null;
        }
        
        

        
    }
}