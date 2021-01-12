using System.Collections.Generic;
using Endorblast.GameServer.Server.Game;
using Microsoft.Xna.Framework;

namespace Endorblast.GameServer.Server.Game
{
    public class NPCManager
    {
        

        private List<ServerNPC> npcs = new List<ServerNPC>();
        public List<ServerNPC> Npcs => npcs;
        
        public void Update(GameTime gameTime)
        {
            foreach (var npc in Npcs)
            {
                npc.Update(gameTime);
            }
        }

        public void AddNPC(ServerNPC newNpc)
        {
            npcs.Add(newNpc);
        }

        public ServerNPC RemoveNPC(string npcName)
        {
            foreach (var npc in Npcs)
                if (npc.Name == npcName)
                    return npc;
            
            return null;
        }

        public ServerNPC RemoveNPC(ushort id)
        {
            foreach (var npc in Npcs)
                if (npc.Id == id)
                    return npc;
            
            return null;
        }
        
    }
}