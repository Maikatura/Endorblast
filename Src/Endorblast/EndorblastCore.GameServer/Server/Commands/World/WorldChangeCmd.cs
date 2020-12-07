using System;
using Lidgren.Network;

namespace EndorblastCore.GameServer.Server.Commands
{
    public class WorldChangeCmd
    {
        public void Receive(NetIncomingMessage inc)
        {
            Console.WriteLine("LOL");
        }
    }
}