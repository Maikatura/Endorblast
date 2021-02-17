using Endorblast.Lib;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Game.Network.Commands;
using Endorblast.Lib.Network;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Endorblast.Lib.Network.Master;
using Endorblast.Lib.Scenes;


namespace Endorblast.Lib
{
    public enum Packets
    {
        AddPlayer,
        SendInput,
    }

    public class NetworkManager
    {
        
        
        public string HostIP = "127.0.0.1";
        public int Port = 5555;
        
        public static string AccountName;
        public static string CharacterName;
        public int WorldID;

        public DateTime LoginTime;
        public DateTime LogoutTime;
        TimeSpan AutoDisconnectTime = new TimeSpan(0, 0, 5);

        public bool isLoggingIn = false;
        
        public NetClient client;
        SynchronizationContext context;
        //public List<Player> players;
        public NetworkState State = NetworkState.None;
        
        public int ping = 0;
        public int oldPing = 0;
        
        private static IPEndPoint m_masterServer;
        private static Dictionary<long, IPEndPoint[]> hostList;

        public static Dictionary<long, IPEndPoint[]> HostList
        {
            get
            {
                return hostList;
            }
            private set
            {
                
            }
        }
        
        
        private static NetworkManager instance = new NetworkManager();
        public static NetworkManager Instance
        {
            get { return instance; }
            private set { return; }
        }

        public static void NewInstance()
        {
            instance = new NetworkManager();
        }
        
        public void Connect(string ip = "", int port = 5555, string configStr = "endorblast-master")
        {
            if (string.IsNullOrEmpty(ip))
                ip = HostIP;

            Console.WriteLine(ip);
            
            
            
            Connect(ip, port);
            
        }

        public void Start()
        {
            hostList = new Dictionary<long, IPEndPoint[]>();
            
            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("game");
            c.EnableMessageType(NetIncomingMessageType.UnconnectedData);
            c.EnableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            
            client = new NetClient(c);
            client.RegisterReceivedCallback(NetworkLoop, context);
            client.Start();
        }

        public void Connect(string IPAddress, int port)
        {
            NetOutgoingMessage hailMessage = client.CreateMessage("Yo wassup!");
            client.Connect(IPAddress, port, hailMessage);
        }
        
        public void GetServerList(string masterServerAddress)
        {
            //
            // Send request for server list to master server
            //
            m_masterServer = new IPEndPoint(NetUtility.Resolve(masterServerAddress), ServerSettings.masterServerPort);

            NetOutgoingMessage listRequest = client.CreateMessage();
            listRequest.Write((byte)MasterPacket.RequestHostList);
            client.SendUnconnectedMessage(listRequest, m_masterServer);
        }

        public void RequestNATIntroduction(long hostid)
        {
            if (hostid == 0)
            {
                Console.WriteLine("Select a host in the list first");
                return;
            }

            if (m_masterServer == null)
                throw new Exception("Must connect to master server first!");

            NetOutgoingMessage om = client.CreateMessage();
            om.Write((byte)MasterPacket.RequestIntroduction);

            // write my internal ipendpoint
            IPAddress mask;
            om.Write(new IPEndPoint(NetUtility.GetMyAddress(out mask), client.Port));

            // write requested host id
            om.Write(hostid);

            // write token
            om.Write("mytoken");

            client.SendUnconnectedMessage(om, m_masterServer);
        }

        public NetOutgoingMessage CreateMessage => client.CreateMessage();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public NetOutgoingMessage CreateMasterMessage() => CLM();
        NetOutgoingMessage CLM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)ServerPacket.Master);
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
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.DebugMessage:
                        Console.WriteLine(message.ReadString());
                        break;
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.ErrorMessage:
                        //NativeMethods.AppendText(m_mainForm.richTextBox1, inc.ReadString());
                        break;
                    case NetIncomingMessageType.UnconnectedData:
                        if (message.SenderEndPoint.Equals(m_masterServer))
                        {
                            // it's from the master server - must be a host
                            var id = message.ReadInt64();
                            var hostInternal = message.ReadIPEndPoint();
                            var hostExternal = message.ReadIPEndPoint();
		
                            hostList[id] = new IPEndPoint[] { hostInternal, hostExternal };

                            // update combo box
                            StateManager.Instance.SetGameState(CurrentGameState.ServerMenu, hostList);
                            
                            foreach (var kvp in hostList)
                                Console.WriteLine(kvp.Key.ToString() + " (" + kvp.Value[1] + ")");
                            
                        }
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        string token = message.ReadString();
                        Console.WriteLine("Nat introduction success to " + message.SenderEndPoint + " token is: " + token);
                        break;
                }
            }
        }

        public void Login(bool loginBool, string name)
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
                case WorldPacket.WorldEnter:
                    Console.WriteLine("Someone wants to spawn!");
                    new WorldCharacterEnterCommand().Read(msg);
                    break;
                case WorldPacket.WorldExit:
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

        
        

        public void ShutdownConnection()
        {
            client.Shutdown("bye");
            
        }
    }
}
