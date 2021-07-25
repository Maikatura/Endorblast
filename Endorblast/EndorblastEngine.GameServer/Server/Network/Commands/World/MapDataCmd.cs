using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class MapDataCmd
    {


        // well can show game with old server :)

        public void Read(NetIncomingMessage inc)
        {
            MapPacket type = (MapPacket)inc.ReadByte();
        
            switch (type)
            {
                case MapPacket.Data:
                    break;
                case MapPacket.WorldEnter:
                    new ServerEnterWorldCmd().Read(inc);
                    break;
                case MapPacket.WorldExit:
                    break;
                case MapPacket.WorldChange:
                    break;
                default:
                    Console.WriteLine("### ERROR : Something went wrong in `WorldDataCmd.cs` on the server!");
                    break;
            }

        }
        
    }
}