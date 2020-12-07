using System;
using System.Threading;
using Lidgren.Network;


namespace EndorblastCore.MasterServer
{
    public class MasterServerScript
    {
        
        private bool isRunning = false;

        private NetPeer server;
        public NetPeer Server => server;
        
        SynchronizationContext context;
        

        public void Start()
        {
            Console.WriteLine("### Starting Master Server.");

            isRunning = true;
            
            
            // Make cfg for server then set it to server config.... Done.
            var c = new NetPeerConfiguration("endorblast");
            c.Port = MasterServerSettings.masterServerPort;
            c.MaximumConnections = MasterServerSettings.maxConnections;
            server = new NetServer(c);
            
            // Make server packet loop :)
            context = new SynchronizationContext();
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();
            
            
        }

        private void NetworkLoop(object o)
        {
            
        }

    }
}