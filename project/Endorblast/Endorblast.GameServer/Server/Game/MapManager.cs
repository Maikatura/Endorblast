using System.Collections.Generic;
using System.Linq;
using Endorblast.Lib;
using Endorblast.Lib.Enums;
using Lidgren.Network;
using Microsoft.Xna.Framework;

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
            worlds.Add(new Map(0, MapType.Town));
        }
        
        public void Update(GameTime gameTime)
        {
            foreach (var map in worlds)
                map.Update(gameTime);

        }

        public void AddWorld(MapType type)
        {
            var map = new Map(worldId, type);
            worlds.Add(map);
            worldId++;
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


        public ServerCharacter GetPlayer(NetConnection con)
        {
            ServerCharacter player;
            foreach (var world in worlds)
            {
                player = world.characterManager.GetConnection(con);

                if (player != null)
                    return player;
            }

            return null;


            // Need to work on the login system :(
            
        }

        public List<ServerCharacter> GetPlayers(int worldId)
        {
            var list = new List<ServerCharacter>();
            
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
                        list.Add(player.connection);
            
            return list;
            
        }

        public Map AddPlayer(ServerCharacter player, int worldID)
        {
            foreach (var map in worlds)
            {
                if (map.worldId == worldID)
                {
                    map.characterManager.Characters.Add(player);
                    return map;
                }
            }

            return null;

        }

        public Map RemovePlayer(int playerID)
        {
            foreach (var map in worlds)
            {
                foreach (var player in map.characterManager.Characters)
                {
                    if (player.playerID == playerID)
                    {
                        map.characterManager.Characters.Remove(player);
                        return map;
                    }
                }
            }

            return null;
        }
        
        public Map RemovePlayer(NetConnection con)
        {
            foreach (var map in worlds)
                if (map.worldId == worldId)
                    foreach (var player in map.characterManager.Characters)
                        if (player.connection == con)
                            map.characterManager.Characters.Remove(player);

            return null;
        }
        
        

        
    }
}