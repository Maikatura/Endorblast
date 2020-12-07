using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib;

namespace EndorblastCore.Server.NetCommands
{
    class CharacterListCommand : NetCommand
    {

        public void Read(NetIncomingMessage msg, StaticCharacter chara)
        {

        }


        public void Send(NetIncomingMessage inc, int worldId)
        {
            var characterManager = CharacterManager.Instance;

            var charList = characterManager.Characters.FindAll(x => x.WorldID != worldId);

            if (charList.Count == 0)
                return;

            var outmsg = ServerManager.Instance.Server.CreateMessage();
            outmsg.Write((byte)CharacterPacket.List);
            outmsg.Write(worldId);

            int count = charList.Count;
            outmsg.Write(count);

            for (int i = 0; i < count; i++)
            {
                var lc = charList[i].ToStaticCharacter();
                outmsg.WriteAllProperties(lc);
            }

            ServerManager.Instance.Server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
        }
    }


}
