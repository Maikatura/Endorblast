using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Game
{
    public class GameDataCmd : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            GamePacket packetType = (GamePacket) inc.ReadByte();
            
            switch (packetType)
            {
                case GamePacket.Token:
                    new SendTokenCmd().Send();
                    break;
                case GamePacket.Logic:
                    new GamePacketData().Read(inc);
                    break;
                case GamePacket.Info:
                    break;
                case GamePacket.MapData:
                    new MapData().Read(inc);
                    break;
                default:
                    Console.WriteLine("Something went wrong in `GameDataCmd.cs` on Client.");
                    break;
            }
        }
        
    }
}