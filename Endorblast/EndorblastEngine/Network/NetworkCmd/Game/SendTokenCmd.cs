using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Game
{
    public class SendTokenCmd : NetCommand
    {

        public void Send()
        {
            var outmsg = netmana.CreateGameMessage();
            
            outmsg.Write((byte)GamePacket.Token);
            outmsg.Write(GameManager.GetLoginToken);

            client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);

        }
        
    }
}