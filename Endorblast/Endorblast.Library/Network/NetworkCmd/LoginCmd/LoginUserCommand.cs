using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Enums;

namespace Endorblast.Library.Network
{
    public class LoginUserCommand : NetCommand
    {
        public void Read(NetIncomingMessage msg)
        {

        }


        public static void Send(string username, string password)
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateMasterMessage();
            outmsg.Write((byte)MasterPacket.RequestLoginAttempt);
            outmsg.Write((byte)LoginPacket.LoginRequest);
            
            outmsg.Write(username);
            outmsg.Write(password);

            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
