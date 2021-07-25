using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.LoginServer.Network.Messages
{
    public class SendErrorCmd : LoginNetCommand
    {

        public void Send(NetConnection user, ErrorCode errorType)
        {
            var outmsg = netmana.CreateNoneMessage();
            outmsg.Write((byte)NonePacket.ErrorCode);
            
            outmsg.Write((byte)errorType);

            server.SendMessage(outmsg, user, NetDeliveryMethod.ReliableOrdered);
        }
    }
}