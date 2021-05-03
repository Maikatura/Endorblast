using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginGameServerCmd
    {
        
        
        
        public void Send(NetConnection con)
        {
            var outmsg = LoginServerScript.Instance.LoginMessage();
            
            
            outmsg.Write((byte)LoginPacket.GameServerInfo);
            
            
            
            

            LoginServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}