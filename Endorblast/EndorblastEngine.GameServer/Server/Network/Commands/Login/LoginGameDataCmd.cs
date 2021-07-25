using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class LoginGameDataCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            LoginRequest type = (LoginRequest) inc.ReadByte();

            switch (type)
            {
                case LoginRequest.ReqCharacters:
                    Console.WriteLine("LOL");
                    break;
                default:
                    Console.WriteLine("Something went wrong in `LoginGameDataCmd.cs` on Game Server.");
                    break;
            }
        }
    }
}