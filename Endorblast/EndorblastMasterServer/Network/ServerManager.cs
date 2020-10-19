using EndorblastServer.Network;
using EndorblastServer.Server.NetCommands;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EndorblastServer
{
    public enum Packets
    {
        AddPlayer,
        SendInput,
    }

    class ServerManager
    {
        NetServer server;
        public NetServer Server => server;

        static ServerManager instance;
        public static ServerManager Instance => instance;

        public static void NewInstance() { instance = new ServerManager(); }

        SynchronizationContext context;
        public ServerManager()
        {
            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast");
            c.Port = 5555;
            c.MaximumConnections = 10;
            server = new NetServer(c);

            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();
        }

        public NetOutgoingMessage CreateMessage => server.CreateMessage();

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

        private void NetworkLoop(object o)
        {
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        PacketType packet = (PacketType)message.ReadByte();
                        Data(packet, message);
                        break;

                    case NetIncomingMessageType.StatusChanged:

                        switch (message.SenderConnection.Status)
                        {
                            case NetConnectionStatus.Connected:

                                Console.WriteLine("King");

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
                        Console.WriteLine("unhandled message with type: " + message.MessageType);
                        break;
                }
            }
        }



        private void Data(PacketType packet, NetIncomingMessage message)
        {
            switch (packet)
            {
                case PacketType.Account:
                    AccountSwitch(message);
                    break;
                case PacketType.Character:
                    Console.WriteLine("King");
                    break;
                default:

                    Console.WriteLine("Someone on the server sending a packet that doesnt exist");
                    break;
            }
        }

        void AccountSwitch(NetIncomingMessage message)
        {
            AccountPacket packet = (AccountPacket)message.ReadByte();

            switch (packet)
            {
                case AccountPacket.LoginState:
                    
                    Console.WriteLine("State! 2");
                    break;
                case AccountPacket.LoginMePlz:
                    LoginUser.Read(message);
                    Console.WriteLine("State!");
                    break;
                default:
                    break;
            }
        }

        
    }
}
