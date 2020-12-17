using System;
using System.Threading;
using Endorblast.Lib.Enums;
using Endorblast.LoginServer.Login.NetCmd;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login
{
    public class LoginServerScript
    {
        
        private static LoginServerScript instance = new LoginServerScript();
        public static LoginServerScript Instance
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
        public NetPeer Server
        {
            get
            {
                return server;
            }
            private set
            {
                return;
            }
        }
        

        SynchronizationContext context;
        
        
        
        
        
        public void Start()
        {
            Console.WriteLine("### Starting Login Server.");

            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast-login");
            c.Port = 5557;
            c.MaximumConnections = 200;
            server = new NetServer(c);
            
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();

            while (true)
            {
                
            }
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
                        ServerPacket packet = (ServerPacket) message.ReadByte();
                        switch (packet)
                        {
                            case ServerPacket.Login:
                                new LoginCmd().Receive(message);
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
    }
}