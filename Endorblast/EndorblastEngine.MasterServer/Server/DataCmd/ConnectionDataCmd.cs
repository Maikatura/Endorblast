using System;
using Endorblast.Library.Enums;
using Endorblast.LoginServer.Login.NetCmd;
using Lidgren.Network;

namespace Endorblast.MasterServer.DataCmd
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
                    new LoginCmd().Read(inc);
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