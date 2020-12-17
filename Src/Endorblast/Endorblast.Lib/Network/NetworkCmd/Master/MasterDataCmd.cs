using System;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.Lib.Network.Master
{
    public class MasterDataCmd
    {
        
        
        public void Read(NetIncomingMessage msg)
        {
            var dataType = (MasterPacket)msg.ReadByte();

            switch (dataType)
            {
                case MasterPacket.SendToLoginServer:
                    new ToLoginServerCmd().Read(msg);
                    break;
                default:
                    Console.WriteLine("THE DATA THAT GOT HERE DOESN'T EXIST!");
                    break;
            }
        }
        
    }
}