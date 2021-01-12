using System;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class WorldChangeCmd : NetCmd
    {
        public void Receive(NetIncomingMessage inc)
        {
            Console.WriteLine("LOL");
        }
    }
}