using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Game
{
    public class GamePacketData : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            GameLogicPacket type = (GameLogicPacket) inc.ReadByte();

            switch (type)
            {
                case GameLogicPacket.RequestCharacter:
                    new ReceiveCharactersCmd().Read(inc);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}