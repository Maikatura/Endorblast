using System;
using System.Collections.Generic;
using System.Threading;
using Endorblast.DBase;
using Endorblast.Lib.Game.Data;
using Endorblast.Library.Enums;
using Endorblast.LoginServer.Login.NetCmd;
using Lidgren.Network;
using MySql.Data.MySqlClient;

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


        public NetOutgoingMessage LoginMessage() => CLM();
        private NetOutgoingMessage CLM()
        {
            var outmsg = Server.CreateMessage();
            outmsg.Write((byte)ServerTypes.Login);
            return outmsg;
        }
        
        
        public void Start()
        {
            Console.WriteLine("### Starting Login Server.");

            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast-login");
            c.Port = 5557;
            c.MaximumConnections = 200;
            c.SetMessageTypeEnabled(NetIncomingMessageType.NatIntroductionSuccess, true);
            server = new NetServer(c);
            
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();


            var data = new LoadAllServerCmd().LoadServers();

            foreach (var server in data)
            {
                Console.WriteLine($"Name: {server.serverName} IP: {server.ipAddress}");
            }
            
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
                        ServerTypes packet = (ServerTypes) message.ReadByte();
                        switch (packet)
                        {
                            case ServerTypes.Login:
                                new LoginCmd().Read(message);
                                break;
                        }
                        
                        break;

                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:
                                Console.WriteLine("Client Connected");
                                break;
                            case NetConnectionStatus.Disconnecting:
                                break;
                            case NetConnectionStatus.Disconnected:
                                break;
                        }
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        Console.WriteLine("Someone connected!");
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