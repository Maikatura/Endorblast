using Endorblast;
using Endorblast.Lib.Enums;
using Lidgren.Network;
using System.Collections.Generic;

namespace EndorblastServer.Server.NetCommands.World
{
    public class EnemyWorldSpawnCommand : NetCommand
    {


        public void Read(NetIncomingMessage inc)
        {

        }


        public void Send(EnemyType type, float x, float y)
        {
            var outmsg = ServerManager.Instance.CreateWorldMessage();
            outmsg.Write((byte)WorldPacket.EnemySpawn);

            outmsg.Write((byte)type);
            outmsg.Write(x);
            outmsg.Write(y);

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);

        }

    }
}
