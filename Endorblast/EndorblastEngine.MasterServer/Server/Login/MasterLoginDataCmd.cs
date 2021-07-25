using System;
using System.Diagnostics;
using Endorblast.Library.Enums;
using Endorblast.LoginServer.Login.NetCmd;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login
{
    public class MasterLoginDataCmd : MasterNet
    {
        public void Read(NetIncomingMessage inc)
        {
            LoginType type = (LoginType)inc.ReadByte();

            switch (type)
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
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}