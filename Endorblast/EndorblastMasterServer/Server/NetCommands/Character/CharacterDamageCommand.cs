using Endorblast.Lib.Enums;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
{
    public class CharacterDamageCommand : NetCommand
    {


        public void Read(NetIncomingMessage inc)
        {

        }


        public void Send(int currentHealth)
        {
            var outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.EnemyDamaged);

            outmsg.Write(currentHealth);

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);

        }

    }
}
