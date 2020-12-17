using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginSuccessCmd
    {
        public void Send(NetConnection con)
        {
            var outmsg = LoginServerScript.Instance.Server.CreateMessage();
            
            outmsg.Write((byte)LoginPacket.LoginSuccess);
            
            LoginServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);
        }
    }
}