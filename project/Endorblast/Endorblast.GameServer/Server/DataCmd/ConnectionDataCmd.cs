using System;
using Endorblast.GameServer.Login;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer
{
    public class ConnectionDataCmd
    {
        public void Receive(NetIncomingMessage inc)
        {
            
            MasterPacket type = (MasterPacket)inc.ReadByte();
            switch (type)
            {
                case MasterPacket.RequestHostList:
                    
                    break;
                case MasterPacket.RequestLoginAttempt:
                    new LoginCmd().Receive(inc);
                    break;
                
                default:
                    Console.WriteLine("### ERROR : unhandled message with type: " + type);
                    break;
            }
            
        }
        

        public void Send()
        {
            
        }
        
    }
}