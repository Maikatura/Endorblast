using System.Net;
using Endorblast.Backend;
using Endorblast.Backend.ServerCmd;

namespace Endorblast.MasterServer.Game
{
    public class SendToGameServer
    {


        public void SendToServer(IPEndPoint client, long identity)
        {
            var serverAddress = ServerManager.Instance.GetGameServer(identity);
            
            MasterServerScript.Instance.Server.Introduce(serverAddress.Value.address[0], serverAddress.Value.address[1],
                client,client, "info.Token");
            
            
        }
    }
}