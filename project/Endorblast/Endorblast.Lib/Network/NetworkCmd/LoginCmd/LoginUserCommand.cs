using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;

namespace Endorblast.Lib.Network
{
    public class LoginUserCommand : NetCommand
    {
        public void Read(NetIncomingMessage msg)
        {

        }


        public static void Send(string username, string password)
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateLoginMessage();
            outmsg.Write((byte)LoginPacket.LoginRequest);
            
            outmsg.Write(username);
            outmsg.Write(password);

            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
