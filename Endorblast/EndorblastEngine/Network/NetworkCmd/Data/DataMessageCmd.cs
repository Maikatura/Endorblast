using System;
using Lidgren.Network;
using NVorbis;
using DataPacket = Endorblast.Library.Enums.DataPacket;

namespace EndorblastEngine.Network.NetworkCmd.Game
{
    public class DataMessageCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            DataPacket packetType = (DataPacket)inc.ReadByte();

            switch (packetType)
            {
                case DataPacket.ERROR:
                    break;
                case DataPacket.Message:
                    break;
                default:
                    Console.WriteLine("Something went wrong in `DataMessageCmd.cs` on client");
                    break;
            }
        }
    }
}