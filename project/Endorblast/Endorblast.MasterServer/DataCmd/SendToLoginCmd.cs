using System;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Lidgren.Network;

namespace Endorblast.MasterServer.DataCmd
{
    public class SendToLoginCmd
    {
        
        public void Send(NetConnection con)
        {
            var outmsg = MasterServerScript.Instance.MASTERMSG();

            Console.WriteLine("## INFO : Sent a player to Login Server.");
            
            // Send Login Server Info
            // TODO : Read Servers from database
            //outmsg.Write((byte)MasterPacket.RequestLoginServer);
            //outmsg.Write(ServerSettings.loginServerPort);
            
            MasterServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);
        }
        
    }
}