using EndorblastCore.Lib;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.Game.Network.Commands;
using EndorblastCore.Lib.Network;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Threading;


namespace EndorblastCore.Lib
{
    public enum Packets
    {
        AddPlayer,
        SendInput,
    }

    public class NetworkManager
    {
        static NetworkManager instance;
        public static NetworkManager Instance => instance;
        public static void NewInstance() 
        { 
            instance = new NetworkManager(); 
        }

        string HostIP = "127.0.0.1";
        int Port = 5555;

        public static string AccountName;
        public static string CharacterName;
        public static int WorldID;

        public DateTime LoginTime;
        public DateTime LogoutTime;

        TimeSpan AutoDisconnectTime = new TimeSpan(0, 0, 5);

        public bool isLoggingIn = false;


        //bool cyrptNetwork = true;
        public NetClient client;
        SynchronizationContext context;

        //float timeoutTimer;

        public List<Player> players;

        //public event EventHandler<UpdatePlayerListEvent> UpdatePlayerListEvent;

        public NetworkState State = NetworkState.None;

        public int ping = 0;
        public int oldPing = 0;

        public NetworkManager()
        {
            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast");
            c.ResendHandshakeInterval = 4.75f;
            c.MaximumHandshakeAttempts = 10;


            client = new NetClient(c);
            client.RegisterReceivedCallback(NetworkLoop, context);
            client.Start();


            Console.WriteLine("LOL");
            NetOutgoingMessage hailMessage = client.CreateMessage("Yo wassup!");
            client.Connect(HostIP, Port, hailMessage);
        }

        public NetOutgoingMessage CreateMessage => client.CreateMessage();

        public NetOutgoingMessage CreateCharacterMessage() => CCM();
        NetOutgoingMessage CCM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)PacketType.Character);
            return msg;
        }

        public NetOutgoingMessage CreateAccountMessage() => CAM();
        NetOutgoingMessage CAM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)PacketType.Account);
            return msg;
        }

        public NetOutgoingMessage CreateWorldMessage() => CWM();
        NetOutgoingMessage CWM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)PacketType.World);
            return msg;
        }


        private void NetworkLoop(object obj)
        {
            


            NetIncomingMessage message;
            while ((message = client.ReadMessage()) != null)
            {
                
                

                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        PacketType packet = (PacketType)message.ReadByte();
                        switch (packet)
                        {
                            case PacketType.World:
                                WorldSwitch(message);
                                break;
                            case PacketType.Account:
                                AccountSwitch(message);
                                break;

                            case PacketType.Character:
                                CharacterSwitch(message);
                                break;
                        }
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        Console.WriteLine("King");
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        Console.WriteLine("Debug");
                        Console.WriteLine(message.ReadString());
                        break;

                    default:
                        Console.WriteLine("unhandled message with type: " + message.MessageType);
                        break;
                }
            }

            
        }

        public void Login(bool loginBool,string name)
        {
            if (loginBool)
            {
                //timeoutTimer = 0;
                isLoggingIn = loginBool;
                AccountName = name;
                
            }
            else
            {
                Console.WriteLine("# FAILED - Not a succesful login.");
            }
            
        }

        void CharacterSwitch(NetIncomingMessage message)
        {
            CharacterPacket packet = (CharacterPacket)message.ReadByte();

            switch (packet)
            {
                case CharacterPacket.SkillCast:
                    
                    new CharacterSkillCastCommand().Read(message);
                    break;
                case CharacterPacket.Data:
                    
                    new CharacterDataCommand().Read(message);

                    break;
                case CharacterPacket.List:

                    break;
                default:
                    break;
            }
        }
        void WorldSwitch(NetIncomingMessage msg)
        {
            WorldPacket packet = (WorldPacket)msg.ReadByte();

            switch (packet)
            {
                case WorldPacket.CharacterEnter:
                    Console.WriteLine("Someone wants to spawn!");
                    new WorldCharacterEnterCommand().Read(msg);
                    break;
                case WorldPacket.CharacterExit:
                    new WorldCharacterExitCommand().Read(msg);
                    break;

                case WorldPacket.EnemySpawn:
                    new EnemySpawnCommand().Read(msg);
                    break;
                default:
                    Console.WriteLine("# WUT?");

                    break;
            }
        }

        void AccountSwitch(NetIncomingMessage msg)
        {
            AccountPacket paket = (AccountPacket)msg.ReadByte();

            switch (paket)
            {
                case AccountPacket.LoginState:
                    
                    LoginStateCommand.Read(msg);
                    break;
                case AccountPacket.LoginMePlz:
                    Console.WriteLine("Test");
                    //LoginStateCommand.Read(msg);
                    break;
            }
        }

    }
}
