using EndorblastServer.Server.Game.Map;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    class WorldDataCommand : NetCommand
    {
        public override void Read(NetIncomingMessage inc, LibCharacter ch)
        {

        }

        public static void Send(NetConnection con, MapType type, int width, int height)
        {
            var outmsg = ServerManager.Instance.Server.CreateMessage();
            outmsg.Write((byte)WorldPacket.Data);
            outmsg.Write((byte)type);
            outmsg.Write(width);
            outmsg.Write(height);

            ServerManager.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered, 0);
        }

    }
}
