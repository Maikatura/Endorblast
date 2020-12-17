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
        
        // Sooooo Bye :)        

        private void ReadLogin(NetIncomingMessage inc)
        {
            string username = inc.ReadString();
            string password = inc.ReadString(); // TODO : hash password on client.


            bool rightLogin = Database.Instance.GetLoginAccount(username, password);

            if (rightLogin)
            {
                Console.WriteLine("Login Success");
                //new LoginSuccessCmd().Send(inc.SenderConnection);
            }
            else
            {
                Console.WriteLine("Login Failed");
                //new LoginFailedCmd().Send(inc.SenderConnection);
            }
        }

        public void Send()
        {
            
        }
        
    }
}