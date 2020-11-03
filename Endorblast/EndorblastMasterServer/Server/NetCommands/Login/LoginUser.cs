using EndorblastServer.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;

namespace EndorblastServer.Server.NetCommands
{
    class LoginUser : NetCommand
    {
        

        static event EventHandler<LoginUserEvent> _Event;
        public static event EventHandler<LoginUserEvent> Event
        {
            add
            {
                _Event = null;
                _Event += value;
            }
            remove
            {
                _Event -= value;
            }
        }

        public static void Read(NetIncomingMessage msg)
        {
            string username = msg.ReadString();
            string password = msg.ReadString();

            if (Database.RightDetails(username, password))
            {
                Console.WriteLine("True");
                Send(msg.SenderConnection, true, username);
            }
            else
            {
                Console.WriteLine("False");
                Send(msg.SenderConnection, false);
            }
        }

        public static void Send(NetConnection con, bool loginStatus, string username = "")
        {
            if (loginStatus)
            {
                NetOutgoingMessage outmsg = ServerManager.Instance.CreateAccountMessage();
                outmsg.Write((byte)AccountPacket.LoginState);


                outmsg.Write(loginStatus);
                outmsg.Write(username);

                int id = Database.LoadCharacterData(username);
                List<DatabaseCharacter> chars = Database.LoadCharacters(id);

                outmsg.Write(chars.Count);

                for (int i = 0; i < chars.Count; i++)
                {
                    Console.WriteLine(chars[i].Name);
                    outmsg.WriteAllFields(chars[i]);
                }

                ServerManager.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered, 0);
            }
            else
            {
               
            }
        }

    }

    class LoginUserEvent : EventArgs
    {
        public bool rightLogin;

        public LoginUserEvent(NetConnection con, string username, string password)
        {
            
        }
    }
}
