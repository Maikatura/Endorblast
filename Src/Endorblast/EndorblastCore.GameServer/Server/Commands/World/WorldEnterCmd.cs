using System;
using Lidgren.Network;

namespace EndorblastCore.GameServer.Server.Commands
{
    public class WorldEnterCommand
    {
        public void Receive(NetIncomingMessage inc)
        {
            Console.WriteLine("LOL");
        }
    }
}