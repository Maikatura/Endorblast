using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.LoginServer.Network
{
    public class LoginServerDataCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            ServerTypes type = (ServerTypes) inc.ReadByte();

            switch (type)
            {
                case ServerTypes.Login:
                    new ServerLoginDataCmd().Read(inc);
                    break;
                default:
                    Console.WriteLine("Something went wrong.");
                    break;
            }
        }
    }
}