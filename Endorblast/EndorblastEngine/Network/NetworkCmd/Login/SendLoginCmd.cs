using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class SendLoginCmd : NetCommand
    {

        public void Send(string username, string password)
        {
            var outmsg= netmana.CreateLoginMessage();
            
            outmsg.Write((byte)LoginType.LoginRequest);
            
            
            outmsg.Write(username);
            outmsg.Write(password);

            client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);

        }
    }
}