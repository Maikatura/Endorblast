using System;
using Endorblast.GameServer.Login.DataCmd;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.Login
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
            
            var rightLogin = new AccountLoginCmd().GetLoginAccount(username, password);
            
            if (rightLogin)
            {
                Console.WriteLine("Login Success");
                new LoginSuccessCmd().Send(inc.SenderConnection, username, 0);
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