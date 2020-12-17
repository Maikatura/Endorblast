using Lidgren.Network;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Endorblast.Server.NetCommands;


namespace Endorblast.Server
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
            c.MaximumConnections = 200;
            server = new NetServer(c);

            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();

            Console.WriteLine($"######################");
            Console.WriteLine($"#  Server Started    #");
            Console.WriteLine($"#  Port: {c.Port}        #");
            Console.WriteLine($"#                    #");
            Console.WriteLine($"######################");
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
                                
                                
                                break;
                            case NetConnectionStatus.Disconnecting:
                                
                                break;
                            case NetConnectionStatus.Disconnected:
                                CharacterManager.Instance.RemovePlayer(message.SenderConnection);
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
                    CharacterSwitch(message);
                    break;

                case PacketType.World:
                    WorldSwitch(message);
                    break;
                default:

                    Console.WriteLine("Someone on the server sending a packet that doesnt exist");
                    break;
            }
        }

        void WorldSwitch(NetIncomingMessage message)
        {
            WorldPacket packet = (WorldPacket)message.ReadByte();

            switch (packet)
            {
                case WorldPacket.Data:
                    break;
                case WorldPacket.WorldEnter:
                    
                    new WorldCharacterEnterCommand().Read(message);
                    break;
                case WorldPacket.WorldExit:
                    break;
                default:
                    Console.WriteLine("Cool");
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


        void CharacterSwitch(NetIncomingMessage message)
        {
            CharacterPacket packet = (CharacterPacket)message.ReadByte();

            switch (packet)
            {
                case CharacterPacket.Data:
                    new Server.NetCommands.CharacterDataCommand().Read(message);

                    break;
                case CharacterPacket.List:

                    break;
                default:
                    break;
            }
        }

    }
}
