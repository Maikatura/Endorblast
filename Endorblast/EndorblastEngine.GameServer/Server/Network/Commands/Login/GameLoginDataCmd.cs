using System;
using Endorblast.Backend.Tokens;
using Endorblast.DBase;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class GameLoginDataCmd : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {
            LoginType type = (LoginType)inc.ReadByte();

            switch (type)
            {
                case LoginType.LoginRequest:
                    break;
                case LoginType.LoginDisconnect:
                    break;
                case LoginType.LoginSuccess:
                    break;
                case LoginType.LoginFailed:
                    break;
                case LoginType.GameServerInfo:
                    new LoginGameDataCmd().Read(inc);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            
            
        }
    }
}