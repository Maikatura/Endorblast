using Endorblast.Lib.Enums;
using Endorblast.MasterServer;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginFailedCmd
    {

        public void Send(NetConnection con)
        {
            var outmsg = MasterServerScript.Instance.MASTERMSG();
            
            outmsg.Write((byte)MasterPacket.Login);
            outmsg.Write((byte)LoginPacket.LoginFailed);
            
            
            // Todo : Log info about client login attempt.
            

            MasterServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}