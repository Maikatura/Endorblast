using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Master
{
    public class RequestGameSerCmd : NetCommand
    {
        public void Read(NetIncomingMessage inc)
        {
        }

        public void Send(string token)
        {
            var outmsg = client.CreateMessage();
            
            outmsg.Write((byte)MasterServerMessageType.RequestGameServers);
            outmsg.Write(token);

            client.SendUnconnectedMessage(outmsg, MasterSettings.Address, MasterSettings.Port);
        }
    }
}