using Endorblast.Lib.Enums;
using Endorblast.LoginServer.Login;
using Lidgren.Network;

namespace Endorblast.GameServer.Login
{
    public class LoginGameServerCmd
    {
        
        
        
        public void Send(NetConnection con)
        {
            var outmsg = GameServerScript.Instance.CreateLoginMessage();
            
            
            outmsg.Write((byte)LoginPacket.GameServerInfo);
            
            
            
            

            GameServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}