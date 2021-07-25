using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd.Game
{
    public class GameLogicDataCmd : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {
            base.Read(inc);

            GameLogicPacket type = (GameLogicPacket) inc.ReadByte();

            switch (type)
            {
                case GameLogicPacket.RequestCharacter:
                    break;
                case GameLogicPacket.RequestJoinGame:
                    Console.WriteLine("Piss off client, you cant join the game because you are an idiot from sweden");
                    break;
                default:
                    Console.WriteLine("Something went wrong in `GameLogicDataCmd.cs`. Fix it!");
                    break;
            }
        }
    }
}