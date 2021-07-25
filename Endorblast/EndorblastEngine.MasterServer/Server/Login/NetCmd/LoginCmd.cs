using System;
using Endorblast.Backend.ServerCmd;
using Endorblast.DBase;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginCmd : MasterNet
    {

        public void Read(NetIncomingMessage inc)
        {
            string username = inc.ReadString();
            string password = inc.ReadString();


            var outmsg = netmana.LOGINMSG();
            outmsg.Write((byte) LoginType.LoginRequest);
            outmsg.Write(username);
            outmsg.Write(password);

            var serverAddress = ServerManager.Instance.GetClient(inc.SenderEndPoint);
            var serverNet = server.GetConnection(serverAddress.Value.address[1]);

            // server.SendMessage(outmsg, serverAddress[0], NetDeliveryMethod.ReliableOrdered);
            Console.WriteLine("Sent To Login Server!");
        }
        

        private void ReadLogin(NetIncomingMessage inc)
        {
            string username = inc.ReadString();
            string password = inc.ReadString(); // TODO : hash password on client.
            
            var rightLogin = new AccountLoginCmd().GetLoginAccount(username, password);
            
            if (!rightLogin.Equals(0))
            {
                Console.WriteLine("Login Success");
                new LoginSuccessCmd().Send(inc.SenderConnection, username, rightLogin);
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