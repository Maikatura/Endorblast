using System;
using System.Net;
using Endorblast.Library.Enums;
using Endorblast.LoginServer.Login.NetCmd;

namespace Endorblast.MasterServer.Game
{
    public class SendGameServers : MasterNet
    {
        public void Send(IPEndPoint user)
        {
            var outmsg = server.CreateMessage();
            
            outmsg.Write((byte)MasterServerMessageType.ClientRecieveServers);

            var listOfServer = new LoadServerList().Load();

            if (listOfServer != null)
            {
                outmsg.Write(listOfServer.Count);
                
                foreach (var server in listOfServer)
                {
                    outmsg.WriteAllFields(server);
                }
            }
            
            
            
            server.SendUnconnectedMessage(outmsg, user);
            
        }
    }
}