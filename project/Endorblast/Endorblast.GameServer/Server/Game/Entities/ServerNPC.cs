using System;
using Microsoft.Xna.Framework;

namespace Endorblast.GameServer.Server.Game
{
    public class ServerNPC
    {

        public ushort Id;
        public string Name = "";

        public ServerNPC(ushort id)
        {
            Id = id;
        }
        
        public void Update()
        {
            Console.WriteLine("NPC Updated");
        }

        public void NPCMessageToClients(string thingToSay)
        {
            // TODO : Fix it
        }
        
    }
}