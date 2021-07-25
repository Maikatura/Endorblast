using System.Collections.Generic;
using Endorblast.Backend.ServerCmd;
using Endorblast.Library;

namespace Endorblast.MasterServer.Game
{
    public class LoadServerList
    {


        public List<ServerInfo> Load()
        {
            var list = ServerManager.Instance.GetGameServers();

            return list;
        }
        
    }
}