using System;
using Endorblast.Backend.Tokens;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class RequestToken : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {
            new SendCharaDataCmd().Read(inc);
        }

        public void Send(NetConnection user)
        {
            var outmsg = netmana.GAMEMSG();
            
            outmsg.Write((byte)GamePacket.Token);

            server.SendMessage(outmsg, user, NetDeliveryMethod.ReliableOrdered);
        }
        
    }
}