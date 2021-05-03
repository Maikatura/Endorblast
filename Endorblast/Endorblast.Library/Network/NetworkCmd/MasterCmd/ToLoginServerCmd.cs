using System;
using Lidgren.Network;

namespace Endorblast.Library.Network.Master
{
    public class ToLoginServerCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            Console.WriteLine("Disconnection from master to connect to login!");
            int port = inc.ReadInt32();
            Console.WriteLine(port);
            
            
            NetworkManager.Instance.ShutdownConnection();
            //NetworkManager.NewInstance("endorblast-login", port);

        }
    }
}