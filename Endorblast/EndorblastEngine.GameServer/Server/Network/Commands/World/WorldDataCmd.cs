using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class WorldDataCmd
    {


        // well can show game with old server :)

        public void Receive(NetIncomingMessage inc)
        {
            WorldPacket type = (WorldPacket)inc.ReadByte();

            switch (type)
            {
               case WorldPacket.WorldEnter:
                   new WorldEnterCommand().Receive(inc);
                   break;
               case WorldPacket.WorldExit:
                   new WorldExitCmd().Receive(inc);
                   break;
               default:
                   Console.WriteLine("### ERROR : World Type doesn't exits!");
                   break;
            }

        }
        
    }
}