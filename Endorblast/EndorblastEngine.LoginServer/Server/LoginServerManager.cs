using System;
using System.Net;
using System.Threading;
using DiscordRPC.Message;
using Endorblast.Backend;
using Endorblast.DBase;
using Endorblast.Library;
using Endorblast.Library.Enums;
using EndorblastEngine.LoginServer.Network;
using Lidgren.Network;
using MySqlX.XDevAPI;

namespace EndorblastEngine.LoginServer
{
    public class LoginServerManager
    {
        private static LoginServerManager instance = new LoginServerManager();
        public static LoginServerManager Instance
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

        private static NetServer server;
        public static NetServer Server
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

        IPEndPoint masterServerEndpoint;

        private int serverPort;


        public NetOutgoingMessage CreateLoginMessage() => CLM();
        private NetOutgoingMessage CLM()
        {
            var outmsg = Server.CreateMessage();
            outmsg.Write((byte)ServerTypes.Login);

            return outmsg;
        }
        
        public NetOutgoingMessage CreateNoneMessage() => CNM();
        private NetOutgoingMessage CNM()
        {
            var outmsg = Server.CreateMessage();
            outmsg.Write((byte)ServerTypes.None);

            return outmsg;
        }
        
        
        public void Start(int port)
        {
            masterServerEndpoint = new IPEndPoint(IPAddress.Parse(MasterSettings.Address), MasterSettings.Port);
            serverPort = port;

            Console.WriteLine("### Starting Login Server.");

            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast-game");
            c.SetMessageTypeEnabled(NetIncomingMessageType.NatIntroductionSuccess, true);
            c.SetMessageTypeEnabled(NetIncomingMessageType.DebugMessage, true);
            

            c.Port = serverPort;
            
            server = new NetServer(c);
            server.Start();

            server.RegisterReceivedCallback(NetworkLoop, context);
            
            var lastRegistered = -60.0f;

            while (true)
            {
                // (re-)register periodically with master server
                if (NetTime.Now > lastRegistered + 60)
                {
                    // register with master server
                    NetOutgoingMessage regMsg = server.CreateMessage();
                    regMsg.Write((byte)MasterServerMessageType.RegisterHost);
                    IPAddress mask;
                    IPAddress adr = NetUtility.GetMyAddress(out mask);
                    
                    regMsg.Write(server.UniqueIdentifier);
                    regMsg.Write((byte)ServerTypes.Login);
                    regMsg.Write(new IPEndPoint(adr, serverPort));
                    Console.WriteLine("Sending registration to master server");
                    server.SendUnconnectedMessage(regMsg, masterServerEndpoint);
                    lastRegistered = (float)NetTime.Now;
                }
                Thread.Sleep(1);
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

                        new LoginServerDataCmd().Read(message);
                        
                        
                        break;
                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                Console.WriteLine("Server : Client Connected");
                                break;
                            case NetConnectionStatus.Disconnecting:
                                break;
                            case NetConnectionStatus.Disconnected:
                                break;
                        }
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        Console.WriteLine("NAT Success");
                        break;
                    case NetIncomingMessageType.WarningMessage:
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