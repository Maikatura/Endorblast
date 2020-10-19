using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
{
    public class WorldCharacterEnterCommand : NetCommand
    {

        public override void Read(NetIncomingMessage msg, LibCharacter chara)
        {
            //var chname = msg.ReadString();

            //var acc = AccountManager.Instance.GetAccount(msg.SenderConnection.ToString());

            //chara = Database.Character.GetCharacter(chname).Result;
            //chara.AccountName = acc.AccountName;
            //chara.Connection = msg.SenderConnection;
            //acc.CurrentCharacterName = chara.Name;

            //var sp = chara.ToSvCharacter();

            //CharacterManager.Instance.AddPlayer(sp);
            //chara.WorldID = sp.WorldID;

            //new CharacterListCommand().Send(msg, char.WorldID);

            //EnemyListCommand().Send(msg);

        }

        public void Send(LibCharacter ch)
        {
            var list = CharacterManager.Instance.GetConnections(ch.Name);
            if (list.Count == 0)
                return;

            var outmsg = ServerManager.Instance.Server.CreateMessage();

            outmsg.Write((byte)WorldPacket.CharacterEnder);
            outmsg.WriteAllProperties(ch);

            ServerManager.Instance.Server.SendMessage(outmsg, list, NetDeliveryMethod.ReliableOrdered, 0);
            Console.WriteLine("WorldChracterEnderCommand - Sent " + ch.Name);
        }
    }
}
