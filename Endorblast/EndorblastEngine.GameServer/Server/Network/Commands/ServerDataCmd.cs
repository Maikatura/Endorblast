using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class ServerDataCmd
    {
        
        public void Receive(NetIncomingMessage inc)
        {
            GameServerTypes type = (GameServerTypes) inc.ReadByte();

            switch (type)
            {
                // Between Server Packets
                case GameServerTypes.Master:
                    break;
                case GameServerTypes.Login:
                    new LoginDataCmd().Receive(inc);
                    break;
                
                // Player Packets
                case GameServerTypes.Player:
                    new PlayerDataCmd().Receive(inc);
                    break;
                case GameServerTypes.World:
                    break;
                case GameServerTypes.Enemy:
                    break;
                default:
                    Console.WriteLine("### ERROR: ServerDataCmd:Something went wrong!");
                    break;

            }
            
            
        }
        
        public void Send()
        {
            Console.WriteLine("Not Implemented!");
        }
        
    }
}