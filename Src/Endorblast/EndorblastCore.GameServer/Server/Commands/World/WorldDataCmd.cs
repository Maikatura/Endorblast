using System;
using EndorblastCore.Lib.Enums;
using Lidgren.Network;

namespace EndorblastCore.GameServer.Server.Commands
{
    public class WorldDataCmd
    {


        public void Receive(NetIncomingMessage inc)
        {
            WorldPacket type = (WorldPacket)inc.ReadByte();

            switch (type)
            {
               case WorldPacket.WorldEnter:
                   new WorldEnterCommand().Receive(inc);
                   break;
               default:
                   Console.WriteLine("### ERROR : World Type doesn't exits!");
                   break;
            }

        }
        
    }
}