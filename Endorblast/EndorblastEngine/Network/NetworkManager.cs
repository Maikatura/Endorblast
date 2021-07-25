using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Endorblast.Library.Enums;
using EndorblastEngine.Network.NetworkCmd;
using EndorblastEngine.Network.NetworkCmd.Master;
using Lidgren.Network;

namespace EndorblastEngine.Network
{
    public class NetworkManager
    {
        #region Variables

        private static NetworkManager instance;
        public static NetworkManager Instance => instance;
        
        private string masterHostIP = "127.0.0.1"; // Change to a config file :)
        private int masterPort = 27540;
        private IPEndPoint masterServer;
        
        private NetClient client;
        public NetClient Client => client;
        
        SynchronizationContext context;
        
        #endregion

        #region Constructor

        public NetworkManager()
        {
            instance = this;
            
            context = new SynchronizationContext();
            var c = new NetPeerConfiguration("endorblast-game");
            
            c.EnableMessageType(NetIncomingMessageType.UnconnectedData);
            c.EnableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            

            c.PingInterval = 2f;
            c.ConnectionTimeout = 10;
            

            client = new NetClient(c);
            client.Start();
            
            client.RegisterReceivedCallback(NetworkLoop, context);
            
            
            
            //Connect(ip, port);
            Thread.Sleep(5000);

            ConnectToMaster("127.0.0.1");
        }

        #endregion
        
        #region Connect Methods
        
        
        public void ConnectToMaster(string masterServerAddress)
        {
            masterServer = new IPEndPoint(NetUtility.Resolve(masterServerAddress), masterPort);

            NetOutgoingMessage om = client.CreateMessage();
            om.Write((byte)MasterServerMessageType.RequestToLogin);

            // write my internal ipendpoint
            IPAddress mask;
            IPAddress adr = NetUtility.GetMyAddress(out mask);
            
            om.Write(new IPEndPoint(adr, client.Port));

            // write token
            om.Write("mytoken");
            
            client.SendUnconnectedMessage(om, masterServer);
        }
        
        
        
        
        #endregion

        #region Network Loop
        private void NetworkLoop(object obj)
        {
            NetIncomingMessage inc;
            while ((inc = client.ReadMessage()) != null)
            {
                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.UnconnectedData:
                        if (inc.SenderEndPoint.Equals(masterServer))
                        {
                            MasterServerMessageType type = (MasterServerMessageType)inc.ReadByte();

                            if (type == MasterServerMessageType.ClientRecieveServers)
                            {
                                Client.Disconnect("Goodbye. Since I wanna join game Server");
                                new LoadServersCmd().Read(inc);
                            }
                        }
                        break;
                    case NetIncomingMessageType.Data:

                        new MessageDataCmd().Read(inc);
                        
                        break;
                    
                    case NetIncomingMessageType.StatusChanged:
                        var status = inc.SenderConnection.Status;
                        switch (status)
                        {
                            case NetConnectionStatus.None:
                                break;
                            case NetConnectionStatus.InitiatedConnect:
                                break;
                            case NetConnectionStatus.ReceivedInitiation:
                                break;
                            case NetConnectionStatus.RespondedAwaitingApproval:
                                break;
                            case NetConnectionStatus.RespondedConnect:
                                break;
                            case NetConnectionStatus.Connected:
                                Console.WriteLine("Connected!");
                                break;
                            case NetConnectionStatus.Disconnecting:
                                break;
                            case NetConnectionStatus.Disconnected:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        client.Connect(inc.SenderEndPoint);
                        
                        break;
                    case NetIncomingMessageType.WarningMessage:
                        // handle debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine("#### Warning: "+ inc.ReadString());
                        break;
                    default:
                        Console.WriteLine("unhandled message with type: " + inc.MessageType);
                        break;
                }
            }
        }
        
        #endregion
        
        #region Message Creator
        
        public NetOutgoingMessage CreateMessage => client.CreateMessage();

        

        public NetOutgoingMessage CreateMasterMessage() => CWM();
        NetOutgoingMessage CWM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)ServerTypes.Master);
            return msg;
        }
        
        public NetOutgoingMessage CreateLoginMessage() => CLM();
        NetOutgoingMessage CLM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)ServerTypes.Login);
            return msg;
        }
        
        public NetOutgoingMessage CreateGameMessage() => CGM();
        NetOutgoingMessage CGM()
        {
            var msg = client.CreateMessage();
            msg.Write((byte)ServerTypes.Game);
            return msg;
        }
        
        #endregion
    }
}