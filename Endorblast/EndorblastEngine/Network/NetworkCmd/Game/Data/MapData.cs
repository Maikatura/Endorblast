using System;
using Endorblast.Library.Enums;
using EndorblastEngine.Network.NetworkCmd.Game;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class MapData
    {
        public void Read(NetIncomingMessage inc)
        {
            MapPacket packetType = (MapPacket) inc.ReadByte();
            
            switch (packetType)
            {
                case MapPacket.WorldEnter:
                    new ClientEnterWorldCmd().Read(inc);
                    break;
            }
        }
    }
}