using System;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginCmd
    {

        public void Receive(NetIncomingMessage inc)
        {
            LoginPacket packet = (LoginPacket) inc.ReadByte();

            switch (packet)
            {
                case LoginPacket.LoginRequest:
                    ReadLogin(inc);
                    break;
                default:
                    Console.WriteLine("### ERROR : Login Packet does not exist!");
                    break;
            }
        }
        

        private void ReadLogin(NetIncomingMessage inc)
        {
            string username = inc.ReadString();
            string password = inc.ReadString(); // TODO : hash password on client.


            Tuple<bool, int> store = Database.Instance.GetLoginAccount(username, password);

            bool rightLogin = store.Item1;
            int userId = store.Item2;
            
            if (rightLogin)
            {
                Console.WriteLine("Login Success");
                new LoginSuccessCmd().Send(inc.SenderConnection, username, userId);
            }
            else
            {
                Console.WriteLine("Login Failed");
                new LoginFailedCmd().Send(inc.SenderConnection);
            }
        }

        public void Send()
        {
            
        }
        
    }
}