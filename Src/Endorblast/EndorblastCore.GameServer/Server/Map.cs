using System.Collections.Generic;
using EndorblastCore.Lib;
using EndorblastCore.Lib.Enums;

namespace EndorblastCore.GameServer.Server
{
    public class Map
    {
        public int worldId;
        public MapType mapType;
        public CharacterManager characterManager;
        
        
        public int Players()
        {
            return characterManager.Characters.Count;
        }
        
        
        public Map(int worldID, MapType type)
        {
            characterManager = new CharacterManager();
            
            worldId = worldID;
            mapType = type;
            
            // Generate map here :)
            // With "Generate" I mean for example rare mobs to spawn
            // or something in that side :P

            
        }
        
        public void Update()
        {
            // Update anything on the world(map) that needs to be updated here!
        }

        public void AddPlayer()
        {
            
        }

        public void RemovePlayer()
        {
            
        }

    }
}