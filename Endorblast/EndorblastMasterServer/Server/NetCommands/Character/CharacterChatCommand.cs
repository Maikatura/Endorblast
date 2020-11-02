using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;

namespace EndorblastServer.Server.NetCommands
{
    class CharacterChatCommand : NetCommand
    {

        public void Read(NetIncomingMessage msg)
        {
            foreach (var item in CharacterManager.Instance.Characters)
            {
                if (item.connection == msg.SenderConnection)
                {
                    string chatMessage = msg.ReadString();
                    Send(item.Name, chatMessage);
                }
            }
        }


        public void Send(string name, string chatMessage)
        {
            NetOutgoingMessage outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Chat);

            outmsg.Write($"{name} : {chatMessage}");

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
