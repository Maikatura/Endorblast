using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EndorblastCore.GameServer.Server.Commands;
using EndorblastCore.Lib.Enums;
using Lidgren.Network;

namespace EndorblastCore.GameServer
{
    class GameServerScript
    {

        private bool isRunning = false;

        private NetPeer server;
        public NetPeer Server => server;
        
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
        
        
        
        public void Start()
        {
            Console.WriteLine("### Starting Game Server.");
            
            GameLogic.Instnace.Init();

            
            
            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast");
            c.Port = 5555;
            c.MaximumConnections = 200;
            server = new NetServer(c);
            
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
