using EndorblastServer.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Random = Nez.Random;

namespace Endorblast.Server.NetCommands
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


                Console.WriteLine("True");
                Send(msg.SenderConnection, true, username);

        }

        public static void Send(NetConnection con, bool loginStatus, string username = "")
        {
            if (loginStatus)
            {
                NetOutgoingMessage outmsg = ServerManager.Instance.CreateAccountMessage();
                outmsg.Write((byte)AccountPacket.LoginState);


                outmsg.Write(loginStatus);
                outmsg.Write(Random.RNG.Next(0,10000000).ToString());

                //int id = Database.LoadCharacterData(username);
                List<DatabaseCharacter> chars = new List<DatabaseCharacter>();
                
                chars.Add(new DatabaseCharacter()
                {
                    hairStyle = 1,
                    clothId = 1,
                    currency = 1000,
                    hatId = 1,
                    Name = "School123",
                    shoeId = 1
                });
                
                
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
