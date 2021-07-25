using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Endorblast.MasterServer;
using Lidgren.Network;

namespace Endorblast.Backend.ServerCmd
{
    public static class ToLoginServerQueue
    {
        

        private static Queue<ClientInfo> loginQueue;


        static ToLoginServerQueue()
        {
            loginQueue = new Queue<ClientInfo>();
        }
        
        public static void AddClientToQueue(ClientInfo client)
        {
            loginQueue.Enqueue(client);

            RunQueue();
        }

        private static void RunQueue()
        {
            while (!ServerManager.Instance.IsLoginServerUp())
            {
                Thread.Sleep(1);
            }

            var clientAddress = loginQueue.Dequeue();
            var serverAddress = ServerManager.Instance.GetCloseServer();
            
            MasterServerScript.Instance.Server.Introduce(serverAddress.Value.address[0], serverAddress.Value.address[1],
                clientAddress.EndPoint[0],clientAddress.EndPoint[1], clientAddress.Token);

            Console.WriteLine("Sent User to login");
        }
        
        
    }
}