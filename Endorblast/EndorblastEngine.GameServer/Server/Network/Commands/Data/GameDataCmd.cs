using System;
using Endorblast.GameServer.NetworkCmd.Game;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd.Data
{
    public class GameDataCmd : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {
            base.Read(inc);

            GamePacket packetType = (GamePacket) inc.ReadByte();

            switch (packetType)
            {
                case GamePacket.Token:
                    new RequestToken().Read(inc);
                    break;
                case GamePacket.Logic:
                    new GameLogicDataCmd().Read(inc);
                    break;
                case GamePacket.Info:
                    break;
                case GamePacket.Data:
                    break;
                case GamePacket.MapData:
                    new MapDataCmd().Read(inc);
                    break;
                default:
                    break;
            }
        }
    }
}