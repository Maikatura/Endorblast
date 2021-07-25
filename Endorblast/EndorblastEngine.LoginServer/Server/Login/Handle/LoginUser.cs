using System;
using Endorblast.Backend.Tokens;
using Endorblast.DBase;
using Endorblast.DBase.Login;
using Endorblast.Library.Enums;
using EndorblastEngine.LoginServer.Login.Messages;
using EndorblastEngine.LoginServer.Network;
using Lidgren.Network;

namespace EndorblastEngine.LoginServer.Login.Handle
{
    public class LoginUser : LoginNetCommand
    {


        public void Read(NetIncomingMessage inc)
        {

            var endUser = inc.SenderConnection;
            
            string user = inc.ReadString();
            string password = inc.ReadString();
            
            var loginResult = TryToLogin(user, password);
            SendResult(endUser, loginResult, user);

        }

        private LoginStatus TryToLogin(string username, string password)
        {
            return new LoginMessage().TestLogin(username, password);
        }


        public void SendResult(NetConnection user, LoginStatus loginResult, string username)
        {
            var outmsg = netmana.CreateLoginMessage();
            
            outmsg.Write((byte)LoginType.LoginRequest);
            
            outmsg.Write((byte)loginResult);

            if (loginResult == LoginStatus.Success)
            {
                string address = user.RemoteEndPoint.Address.ToString();
                
                var loginToken = new GenerateToken().Generate(username, address);
                new SaveTokenDB().UpdateOrSaveToken(username, loginToken);
                
                outmsg.Write(username);
                outmsg.Write(loginToken);
            }
                
                

            server.SendMessage(outmsg, user, NetDeliveryMethod.ReliableOrdered);
        }
        
        
    }
}