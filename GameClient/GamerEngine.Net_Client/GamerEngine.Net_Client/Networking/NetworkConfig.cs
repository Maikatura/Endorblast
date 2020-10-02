using System;
using System.Threading;
using KaymakNetwork.Network;
using KaymakNetwork.Network.Client;

namespace GamerEngineNet_Client
{
    internal static class NetworkConfig
    {

        internal static Client socket;

        internal static void InitNetwork()
        {
            if (!ReferenceEquals(socket, null)) return;

            socket = new Client(100);

            NetworkReceive.PacketRouter();
        }

        internal static void ConnectToServer()
        {
            while (socket == null)
            {

            }

            socket.Connect("localhost", 5555);

        }

        internal static void DisconnectFromServer()
        {
            socket.Disconnect();
            
        }

    }
}
