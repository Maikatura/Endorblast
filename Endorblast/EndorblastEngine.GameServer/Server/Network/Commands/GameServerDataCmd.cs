using System;
using Endorblast.GameServer.NetworkCmd.Data;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class GameServerDataCmd : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {

            ServerTypes type = (ServerTypes)inc.ReadByte();

            switch (type)
            {
                case ServerTypes.None:
                    break;
                case ServerTypes.Master:
                    break;
                case ServerTypes.Login:
                    new GameLoginDataCmd().Read(inc);
                    break;
                case ServerTypes.Game:
                    new GameDataCmd().Read(inc);
                    break;
                case ServerTypes.Chat:
                    break;
                case ServerTypes.API:
                    break;
                default:
                    Console.WriteLine("Something went wrong in `ServerDataCmd.cs` on Game Server.");
                    break;
            }

        }
        
        
        
    }
}