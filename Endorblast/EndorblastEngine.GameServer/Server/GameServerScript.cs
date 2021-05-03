using System;
using System.Net;
using System.Threading;
using Endorblast.GameServer.Entities;
using Endorblast.GameServer.NetworkCmd;
using Endorblast.GameServer.Server;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer
{
    class GameServerScript
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
        
        #region Packets Types
        public NetOutgoingMessage CreateCharacterMessage() => CCM();
        NetOutgoingMessage CCM()
        {
            var msg = server.CreateMessage();
            msg.Write((byte)PacketType.Character);
            return msg;
        }

        public NetOutgoingMessage CreateAccountMessage() => CAM();
        NetOutgoingMessage CAM()
        {
            var msg = server.CreateMessage();
            msg.Write((byte)PacketType.Account);
            return msg;
        }



        public NetOutgoingMessage CreateWorldMessage() => CWM();
        NetOutgoingMessage CWM()
        {
            var msg = server.CreateMessage();
            msg.Write((byte)PacketType.World);
            return msg;
        }

        
        #endregion

        private IPEndPoint masterServerEndpoint;
        float lastRegistered = -60.0f;
        
        public void Start()
        {
            masterServerEndpoint =
                NetUtility.Resolve("localhost", Library.Network.ServerSettings.masterServerPort);
            
            NetPeerConfiguration config = new NetPeerConfiguration("game");
            config.SetMessageTypeEnabled(NetIncomingMessageType.NatIntroductionSuccess, true);
            config.Port = 5558;
            
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("### Starting Game Server in 5 seconds");

            TimeLogic.Instance.Init();
            
            context = new SynchronizationContext();
            server = new NetServer(config);
            
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();
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
                        new ServerDataCmd().Receive(message);
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
