using System;
using System.Net;
using System.Threading;
using Endorblast.Backend;
using Endorblast.GameServer.Entities;
using Endorblast.GameServer.NetworkCmd;
using Endorblast.GameServer.Server;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer
{
    public class GameServerScript
    {
        
        
        
        private static GameServerScript instance = new GameServerScript();
        public static GameServerScript Instance
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
        
        public NetOutgoingMessage GAMEMSG() => GameMessage();

        private NetOutgoingMessage GameMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte) ServerTypes.Game);

            return msg;
        }
        
        public NetOutgoingMessage LOGINMSG() => LoginMessage();

        private NetOutgoingMessage LoginMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte) ServerTypes.Login);

            return msg;
        }
        

        
        public void Start(int port)
        {
            masterServerEndpoint = new IPEndPoint(IPAddress.Parse(MasterSettings.Address), MasterSettings.Port);
            serverPort = port;

            Console.WriteLine("### Starting Game Server.");

            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast-game");
            c.SetMessageTypeEnabled(NetIncomingMessageType.NatIntroductionSuccess, true);
            c.SetMessageTypeEnabled(NetIncomingMessageType.DebugMessage, true);
            

            c.Port = serverPort;
            
            server = new NetServer(c);
            server.Start();

            server.RegisterReceivedCallback(NetworkLoop, context);
            
            var lastRegistered = -60.0f;

            
            // Send to master that this server is still active!
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
                    regMsg.Write((byte)ServerTypes.Game);
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

                        new GameServerDataCmd().Read(message);
                        
                        break;
                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                Console.WriteLine("Client Connected");
                                new RequestToken().Send(message.SenderConnection);
                                
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
