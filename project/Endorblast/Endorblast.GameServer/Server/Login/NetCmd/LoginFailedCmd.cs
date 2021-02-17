using Endorblast.GameServer;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.Login
{
    public class LoginFailedCmd
    {

        public void Send(NetConnection con)
        {
            var outmsg = GameServerScript.Instance.CreateLoginMessage();
            
            outmsg.Write((byte)MasterPacket.Login);
            outmsg.Write((byte)LoginPacket.LoginFailed);
            
            
            // Todo : Log info about client login attempt.
            

            GameServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}