using System;
using Endorblast.Backend;
using Endorblast.Library.Enums;
using EndorblastEngine.LoginServer.Login.Handle;
using EndorblastEngine.Network.NetworkCmd;
using Lidgren.Network;

namespace EndorblastEngine.LoginServer.Network
{
    public class ServerLoginDataCmd : LoginNetCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            
                LoginType type = (LoginType)inc.ReadByte();

                switch (type)
                {
                    case LoginType.LoginRequest:
                        new LoginUser().Read(inc);
                        break;
                    default:
                        Console.WriteLine("Something went wrong.");
                        break;
                }
        }
    }
}