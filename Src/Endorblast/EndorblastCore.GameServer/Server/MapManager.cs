using System.Collections.Generic;
using EndorblastCore.Lib.Enums;

namespace EndorblastCore.GameServer.Server
{
    public class MapManager
    {
        
        
        private static MapManager instance;
        public static MapManager Instance => instance;
        
        
        public List<Map> worlds = new List<Map>();
        private int worldId = 0;


        public void Update()
        {
            var removeList = new List<Map>();
            foreach (var map in worlds)
            {
                if (map != null)
                {
                    if (map.Players() < 0)
                    {
                        map.Update(); 
                    }
                    else
                    {
                        removeList.Add(map);
                    }
                }
            }

            if (removeList.Count <= 1)
            {
                foreach (var map in removeList)
                {
                    RemoveWorld(map);
                }
            }
            
        }

        public void AddWorld(MapType type)
        {
            var map = new Map(worldId, type);
            worlds.Add(map);
            
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
        
    }
}