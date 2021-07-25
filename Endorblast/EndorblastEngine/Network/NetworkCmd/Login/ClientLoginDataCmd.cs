using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class ClientLoginDataCmd : NetCommand
    {



        public void Read(NetIncomingMessage inc)
        {
            LoginType packetType = (LoginType) inc.ReadByte();

            switch (packetType)
            {
                case LoginType.LoginRequest:
                    new LoginCmd().Read(inc);
                    break;
                case LoginType.LoginDisconnect:
                    break;
                case LoginType.LoginSuccess:
                    break;
                case LoginType.LoginFailed:
                    break;
                case LoginType.GameServerInfo:
                    break;
                
                default:
                    Console.WriteLine("Something went wrong in `LoginDataCmd.cs`");
                    break;
            }
        }
        
    }
}