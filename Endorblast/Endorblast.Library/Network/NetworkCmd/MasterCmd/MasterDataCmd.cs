using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.Library.Network.Master
{
    public class MasterDataCmd
    {
        
        
        public void Read(NetIncomingMessage msg)
        {
            var dataType = (MasterPacket)msg.ReadByte();

            switch (dataType)
            {
                case MasterPacket.RequestLoginAttempt:
                    
                    break;
                case MasterPacket.Login:
                    new LoginDataCmd().Read(msg);
                    
                    break;
                default:
                    Console.WriteLine("THE DATA THAT GOT HERE DOESN'T EXIST!");
                    break;
            }
        }
        
    }
}