using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginFailedCmd
    {

        public void Send(NetConnection con)
        {
            var outmsg = LoginServerScript.Instance.LoginMessage();
            
            
            outmsg.Write((byte)LoginPacket.LoginFailed);
            
            
            // Todo : Log info about client login attempt.
            

            LoginServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}