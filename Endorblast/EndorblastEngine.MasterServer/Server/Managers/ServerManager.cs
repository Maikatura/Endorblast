using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Endorblast.DBase;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Endorblast.MasterServer.Game;
using Lidgren.Network;

namespace Endorblast.Backend.ServerCmd
{
    public class ServerManager
    {
        
        private static ServerManager instance;
        public static ServerManager Instance => instance;
        
        public Dictionary<long, ServerBackInfo> registeredHosts = new Dictionary<long, ServerBackInfo>();


        private string serverAcceptToken = "";


        public ServerManager()
        {
            instance = this;

            serverAcceptToken = new ServerAuthCmd().GetToken();
        }

        public KeyValuePair<long, ServerBackInfo> GetGameServer(long serverIdentity)
        {
            var server = registeredHosts.FirstOrDefault(x => x.Value.token == serverIdentity);
            
            return server;
        }
        
        public List<ServerInfo> GetGameServers()
        {
            var list = new List<ServerInfo>();

            foreach (var server in registeredHosts)
            {
                if (server.Value.serverType == ServerTypes.Game)
                {
                    list.Add(new ServerInfo()
                    {
                        ServerIdentity = server.Value.token
                    });

                    Console.WriteLine("Added A Game Server!");
                }
                    
            }
            
            
            
            return list;
        }

        public KeyValuePair<long, ServerBackInfo> GetCloseServer()
        {
            var server = registeredHosts.FirstOrDefault(x => x.Value.serverType == ServerTypes.Login);
            
            
            return server;
        }

        public KeyValuePair<long, ServerBackInfo> GetClient(IPEndPoint client)
        {
            foreach (var server in registeredHosts)
            {
                server.Value.connectedClients.Contains(client);
                return server;
            }

            return default;
        }

        public bool IsLoginServerUp()
        {
            try
            {
                bool isUp = registeredHosts.FirstOrDefault(x => x.Value.serverType == ServerTypes.Login).Value != null;
                return isUp;
            }
            catch
            {
                return false;
            }
        }

        
    }
}