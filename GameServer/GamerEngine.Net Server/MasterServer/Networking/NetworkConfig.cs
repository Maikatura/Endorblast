using System;
using System.Collections.Generic;
using System.Text;
using KaymakNetwork.Network.Server;
using Microsoft.Xna.Framework;

namespace MasterServer
{
    internal static class NetworkConfig
    {

        private static Server _socket;

        internal static Server Socket
        {
            get { return _socket; }
            set
            {
                if (_socket != null)
                {
                    _socket.ConnectionReceived -= Socket_ConnectionReceived;
                    _socket.ConnectionLost -= Socket_ConnectionLost;
                }

                _socket = value;

                if (_socket != null)
                {
                    _socket.ConnectionReceived += Socket_ConnectionReceived;
                    _socket.ConnectionLost += Socket_ConnectionLost;
                }
            }
        }

        internal static void InitNetwork()
        {
            if (!(Socket == null))
            {
                return;
            }

            Socket = new Server(100)
            {
                BufferLimit = 2048000,
                PacketAcceptLimit = 100,
                PacketDisconnectCount = 150
            };

            NetworkReceive.PacketRouter();
        }

        internal static void Socket_ConnectionReceived(int connectionID)
        {
            Console.WriteLine($"Connection recevied on index[{connectionID}]");
            NetworkSend.WelcomeMessage(connectionID, "Welcome to the server");
            UIManager.UpdateLabel();
        }

        internal static void Socket_ConnectionLost(int connectionID)
        {
            Console.WriteLine($"Connection lost on index[{connectionID}]");
            GameManager.DeletePlayer(connectionID);
            NetworkSend.SendRemovePlayer(connectionID);
            UIManager.UpdateLabel();
        }

    }
}
