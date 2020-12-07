using EndorblastServer.Network;
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
    public class WorldCharacterEnterCommand : NetCommand
    {

        public void Read(NetIncomingMessage msg)
        {
            string username = msg.ReadString();
            bool isLoggedIn = msg.ReadBoolean();

            if (isLoggedIn)
            {
                var chara = new EndorblastCore.Lib.BasePlayer(username, msg.SenderConnection);
                CharacterManager.Instance.AddPlayer(chara);


                new WorldCharacterEnterCommand().Send(chara.ToStaticCharacter());
            }
            else
            {
                Console.WriteLine($"### WARNING - - {msg.SenderConnection} Tried to login with out being logged in!");
            }

        }

        public void Send(EndorblastCore.Lib.StaticCharacter ch)
        {
            foreach (var item in CharacterManager.Instance.Characters)
            {
                if (item.connection != ch.connection)
                {
                    var outmsg = CreateMessage(item.ToStaticCharacter());
                    ServerManager.Instance.Server.SendMessage(outmsg, ch.connection, NetDeliveryMethod.ReliableOrdered);
                }
            }

            foreach (var item in CharacterManager.Instance.Characters)
            {
                    var outmsg = CreateMessage(ch);
                    ServerManager.Instance.Server.SendMessage(outmsg, item.connection, NetDeliveryMethod.ReliableOrdered);
            }

            

            //outmsg.WriteAllProperties(ch);
            Console.WriteLine("WorldChracterEnderCommand - Sent " + ch.AccountName);
        }

        NetOutgoingMessage CreateMessage(EndorblastCore.Lib.StaticCharacter ch)
        {
            var outmsg = ServerManager.Instance.CreateWorldMessage();
            outmsg.Write((byte)WorldPacket.WorldEnter);
            outmsg.Write(ch.WorldID);
            outmsg.Write(ch.Name);
            outmsg.Write(ch.PosX);
            outmsg.Write(ch.PosY);
            

            return outmsg;
        }
    }
}
