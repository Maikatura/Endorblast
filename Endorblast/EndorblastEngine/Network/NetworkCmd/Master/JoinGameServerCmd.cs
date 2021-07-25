using Endorblast.Library;
using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;

namespace EndorblastEngine.Network.NetworkCmd.Master
{
    public class JoinGameServerCmd : NetCommand
    {
        public void Send(long serverIdentity)
        {

            var outmsg = client.CreateMessage();
            
            outmsg.Write((byte)MasterServerMessageType.JoinGameServer);
            
            outmsg.Write(serverIdentity);
            outmsg.Write(GameManager.GetLoginToken);
            
            client.SendUnconnectedMessage(outmsg, MasterSettings.Address, MasterSettings.Port);


        }
    }
}