using System;
using System.Threading.Channels;
using System.Xml.Schema;
using Endorblast.Library.Enums;
using EndorblastEngine.Network.NetworkCmd.Game;
using EndorblastEngine.Network.NetworkCmd.None;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class MessageDataCmd
    {

        public void Read(NetIncomingMessage inc)
        {

            var packetType = (ServerTypes)inc.ReadByte();

            switch (packetType)
            {
                case ServerTypes.None:
                    new NoneDataCmd().Read(inc);
                    break;
                case ServerTypes.Master:
                    break;
                case ServerTypes.Login:
                    new ClientLoginDataCmd().Read(inc);
                    break;
                case ServerTypes.Game:
                    new GameDataCmd().Read(inc);
                    break;
                case ServerTypes.Chat:
                    break;
                case ServerTypes.API:
                    break;
                case ServerTypes.DATA:
                    new DataMessageCmd().Read(inc);
                    break;
                default:
                    Console.WriteLine("Something went wrong in `MessageDataCmd.cs`!");
                    break;
            }

        }
        
        
    }
}