using System.Collections.Generic;
using Endorblast.GameServer.Server.Game;
using Endorblast.Lib;
using Endorblast.Lib.Enums;
using Microsoft.Xna.Framework;

namespace Endorblast.GameServer.Server
{
    public class Map
    {
        public int worldId;
        public MapType mapType;
        public CharacterManager characterManager;
        public NPCManager npcManager;
        
        
        public int Players()
        {
            return characterManager.Characters.Count;
        }
        
        
        public Map(int worldID, MapType type)
        {
            characterManager = new CharacterManager();
            npcManager = new NPCManager();
            
            worldId = worldID;
            mapType = type;
            
            // Generate map here :)
            // With "Generate" I mean for example rare mobs to spawn
            // or something in that side :P

            
        }
        
        public void Update(GameTime gameTime)
        {
            // Update anything on the world(map) that needs to be updated here!
            characterManager.Update(gameTime);
            npcManager.Update(gameTime);
        }

        public void AddPlayer()
        {
            
        }

        public void RemovePlayer()
        {
            
        }

    }
}