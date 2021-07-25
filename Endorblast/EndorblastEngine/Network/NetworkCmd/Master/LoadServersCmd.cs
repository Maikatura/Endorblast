using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Endorblast.Library;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Master
{
    public class LoadServersCmd : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {

            var serverList = new List<ServerInfo>();
            var count = inc.ReadInt32();

            for (int i = 0; i < count; i++)
            {

                var newServer = new ServerInfo();
                inc.ReadAllFields(newServer );
                serverList.Add(newServer);
                Console.WriteLine(newServer.ServerIdentity);
            }

            
            SceneManager.Instance.LoadServers(serverList);

        }
        
    }
}