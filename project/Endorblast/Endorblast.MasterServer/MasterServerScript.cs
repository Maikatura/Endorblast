using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Lidgren.Network;


namespace Endorblast.MasterServer
{
    public class MasterServerScript
    {
	    private string secretServerToken = "LOSLdasjlksdjdgfljsdlf";
	    
	    
        private static MasterServerScript instance = new MasterServerScript();
        public static MasterServerScript Instance
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
        public NetPeer Server => server;
        
        SynchronizationContext context;
        
        private IPEndPoint masterServer;
        
        Dictionary<long, IPEndPoint[]> registeredHosts = new Dictionary<long, IPEndPoint[]>();
        

        public void Start()
        {
            Console.WriteLine("### Starting Master Server.");

            isRunning = true;
            
            // Make cfg for server then set it to server config.... Done.
            var c = new NetPeerConfiguration("game");
            c.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
            c.Port = ServerSettings.masterServerPort;
            server = new NetServer(c);
            
            // Make server packet loop :)
            context = new SynchronizationContext();
            server.RegisterReceivedCallback(NetworkLoop, context);
            server.Start();

            // So it doesn't close
            while (true)
            {
                
            }
        }

        public NetOutgoingMessage MASTERMSG() => masterMessage();

        private NetOutgoingMessage masterMessage()
        {
            var msg = Server.CreateMessage();
            msg.Write((byte)ServerPacket.Master);
            
            return msg;
        }

        private void NetworkLoop(object o)
        {
	        Console.WriteLine(registeredHosts.Count);
	        
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.UnconnectedData:
                        switch ((MasterPacket)message.ReadByte())
							{
								case MasterPacket.RegisterHost:
									// It's a host wanting to register its presence
									var id = message.ReadInt64(); // server unique identifier

									Console.WriteLine("Got registration for host " + id);
									registeredHosts[id] = new IPEndPoint[]
									{
										message.ReadIPEndPoint(), // internal
										message.SenderEndPoint // external
									};
									break;
								case MasterPacket.RequestHostList:
									// It's a client wanting a list of registered hosts
									Console.WriteLine("Sending list of " + registeredHosts.Count + " hosts to client " + message.SenderEndPoint);
									foreach (var kvp in registeredHosts)
									{
										// send registered host to client
										NetOutgoingMessage om = server.CreateMessage();
										om.Write(kvp.Key);
										om.Write(kvp.Value[0]);
										om.Write(kvp.Value[1]);
										server.SendUnconnectedMessage(om, message.SenderEndPoint);
									}

									break;
								case MasterPacket.RequestIntroduction:
									// It's a client wanting to connect to a specific (external) host
									IPEndPoint clientInternal = message.ReadIPEndPoint();
									long hostId = message.ReadInt64();
									string token = message.ReadString();

									Console.WriteLine(message.SenderEndPoint + " requesting introduction to " + hostId + " (token " + token + ")");

									// find in list
									IPEndPoint[] elist;
									if (registeredHosts.TryGetValue(hostId, out elist))
									{
										// found in list - introduce client and host to eachother
										Console.WriteLine("Sending introduction...");
										server.Introduce(
											elist[0], // host internal
											elist[1], // host external
											clientInternal, // client internal
											message.SenderEndPoint, // client external
											token // request token
										);
									}
									else
									{
										Console.WriteLine("Client requested introduction to nonlisted host!");
									}
									break;
							}
							break;
                    case NetIncomingMessageType.Data:
                        
                        break;
                    
                    case NetIncomingMessageType.ErrorMessage:
	                    // print diagnostics message
	                    Console.WriteLine(message.ReadString());
	                    break;
                    case NetIncomingMessageType.DebugMessage:
	                    // handle debug messages
	                    // (only received when compiled in DEBUG mode)
	                    Console.WriteLine(message.ReadString());
	                    break;
                    
                }
            }
        }

        private void DataSwitch(NetIncomingMessage msg)
        {
            
        }

    }
}