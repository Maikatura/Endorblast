using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Channels;
using Endorblast.Backend;
using Endorblast.Backend.ServerCmd;
using Endorblast.DBase.LoadDataCmd.Data;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Endorblast.Library.Network;
using Endorblast.LoginServer.Login;
using Endorblast.MasterServer.DataCmd;
using Endorblast.MasterServer.Game;
using EndorblastEngine.LoginServer.Network.Messages;
using Lidgren.Network;


namespace Endorblast.MasterServer
{
    public class MasterServerScript
    {
        private static MasterServerScript instance;

        public static MasterServerScript Instance
        {
            get { return instance; }
            private set { return; }
        }

        private bool isRunning = false;

        private NetPeer server;
        public NetPeer Server => server;

        SynchronizationContext context;

        private IPEndPoint masterServer;
        private ServerManager servManager;


        public void Start(int port)
        {
            instance = this;
            servManager = new ServerManager();


            Console.WriteLine("### Starting Master Server.");

            isRunning = true;
            // Make cfg for server then set it to server config.... Done.
            var c = new NetPeerConfiguration("endorblast-master");
            c.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
            c.Port = port;
            
            

            server = new NetPeer(c);
            server.Start();
            // Make server packet loop :)
            context = new SynchronizationContext();
            server.RegisterReceivedCallback(NetworkLoop, context);
            
        }

        public NetOutgoingMessage MASTERMSG() => MasterMessage();

        private NetOutgoingMessage MasterMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte) ServerTypes.Master);

            return msg;
        }

        public NetOutgoingMessage LOGINMSG() => LoginMessage();

        private NetOutgoingMessage LoginMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte) ServerTypes.Login);

            return msg;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: Enumerator[Endorblast.Backend.ServerBackInfo,System.Net.IPEndPoint[]]")]
        private void NetworkLoop(object o)
        {
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        

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
                    case NetIncomingMessageType.UnconnectedData:
                        //
                        // We've received a message from a client or a host
                        //

                        // by design, the first byte always indicates action
                        switch ((MasterServerMessageType) message.ReadByte())
                        {
                            case MasterServerMessageType.RegisterHost:

                                // It's a host wanting to register its presence
                                var id = message.ReadInt64(); // server unique identifier
                                ServerTypes type = (ServerTypes) message.ReadByte();

                                var address = message.ReadIPEndPoint();

                                Console.WriteLine("Got registration for host " + id);
                                ServerManager.Instance.registeredHosts[id] = new ServerBackInfo(new IPEndPoint[]
                                {
                                    address,
                                    address
                                })
                                {
                                    serverType = type
                                };
                                break;

                            case MasterServerMessageType.RequestToLogin:
                                // It's a client wanting a list of registered hosts

                                var IPEndPint = message.ReadIPEndPoint();
                                string clientToken = message.ReadString();
                                ToLoginServerQueue.AddClientToQueue(new ClientInfo()
                                {
                                    EndPoint = new IPEndPoint[]
                                    {
                                        IPEndPint, 
                                        IPEndPint
                                    },
                                    Token = clientToken
                                });                             

                                break;
                            case MasterServerMessageType.RequestIntroduction:


                                break;
                            case MasterServerMessageType.RequestToJoinGame:

                                var username = message.ReadString();
                                var clientTokenString = message.ReadString();
                                
                                var serverToken = new GetTokenCmd().GetToken(username);
                                
                                if (clientTokenString == serverToken)
                                {
                                    new SendGameServers().Send(message.SenderEndPoint);
                                }
                                    
                                
                                break;
                            case MasterServerMessageType.JoinGameServer:

                                var serverIdentity = message.ReadInt64();
                                var userToken = message.ReadString();

                                var endPoint = message.SenderEndPoint;
                                
                                new SendToGameServer().SendToServer(endPoint, serverIdentity);


                                break;
                            
                            case MasterServerMessageType.RequestGameServers:

                                
                                
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