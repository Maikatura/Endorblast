using EndorblastServer.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Entities;

namespace Endorblast.Server.NetCommands
{
    public class WorldCharacterExitCommand
    {
        public void Read(NetIncomingMessage msg)
        {
            var ch = new StaticCharacter();

            msg.ReadAllFields(ch);

            CharacterManager.Instance.RemovePlayer(ch.connection);

            //_Event?.Invoke(this, new WorldCharacterEneterEvent(ch));
        }

        public void Send(StaticCharacter ch)
        {
            var list = CharacterManager.Instance.GetConnections(ch.Name);
            if (list.Count == 0)
                return;

           

            var outmsg = ServerManager.Instance.CreateWorldMessage();
            outmsg.Write((byte)WorldPacket.WorldExit);
            outmsg.Write(ch.Name);

            

            ServerManager.Instance.Server.SendMessage(outmsg, list, NetDeliveryMethod.ReliableOrdered, 0);
        }

        public void Send(int id)
        {

        }

        public void Send(NetConnection con)
        {

        }
    }
}
