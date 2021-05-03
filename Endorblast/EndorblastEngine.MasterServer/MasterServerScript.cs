using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Endorblast.Library.Enums;
using Endorblast.Library.Network;
using Endorblast.MasterServer.DataCmd;
using Lidgren.Network;


namespace Endorblast.MasterServer
{
    public class MasterServerScript
    {
        
        private static MasterServerScript instance = new MasterServerScript();
        public static MasterServerScript Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                return;
            }
        }
        
        private bool isRunning = false;

        private NetPeer server;
        public NetPeer Server => server;
        
        SynchronizationContext context;
        
        private IPEndPoint masterServer;
        
        Dictionary<long, IPEndPoint[]> registeredHosts = new Dictionary<long, IPEndPoint[]>();
        

        public void Start()
        {
            Console.WriteLine("### Starting Master Server.");

            isRunning = true;
            
            
            // Make cfg for server then set it to server config.... Done.
            var c = new NetPeerConfiguration("endorblast-master");
            c.Port = ServerSettings.masterServerPort;
            c.MaximumConnections = ServerSettings.maxConnections;
            server = new NetServer(c);
            
            // Make server packet loop :)
            context = new SynchronizationContext();
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();
            

        }

        public NetOutgoingMessage MASTERMSG() => MasterMessage();

        private NetOutgoingMessage MasterMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte)ServerPacket.Master);
            
            return msg;
        }
        
        public NetOutgoingMessage LOGINMSG() => LoginMessage();

        private NetOutgoingMessage LoginMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte)ServerPacket.Login);
            
            return msg;
        }

        private void NetworkLoop(object o)
        {
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        ServerPacket type = (ServerPacket)message.ReadByte();
                        switch (type)
                        {
                            case ServerPacket.Master:
                                new ConnectionDataCmd().Receive(message);
                                break;
                        }
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                break;
                            case NetConnectionStatus.Disconnecting:
                                break;
                            case NetConnectionStatus.Disconnected:
                                break;
                        }
                        break;
                    case NetIncomingMessageType.DebugMessage:
                        // handle debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine(message.ReadString());
                        break;
                    /* .. */
                    default:
                        Console.WriteLine("### ERROR : unhandled message with type: " + message.MessageType);
                        break;
                }
            }
        }

        private void DataSwitch(NetIncomingMessage msg)
        {
            
        }

    }
}