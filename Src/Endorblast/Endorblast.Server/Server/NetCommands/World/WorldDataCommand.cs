using Lidgren.Network;
using Endorblast.Lib.Entities;

namespace Endorblast.Server.NetCommands
{
    class WorldDataCommand : NetCommand
    {
        public void Read(NetIncomingMessage inc, StaticCharacter ch)
        {

        }

        //public static void Send(NetConnection con, MapType type, int width, int height)
        //{
        //    var outmsg = ServerManager.Instance.Server.CreateMessage();
        //    outmsg.Write((byte)WorldPacket.Data);
        //    outmsg.Write((byte)type);
        //    outmsg.Write(width);
        //    outmsg.Write(height);

        //    ServerManager.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered, 0);
        //}

    }
}
