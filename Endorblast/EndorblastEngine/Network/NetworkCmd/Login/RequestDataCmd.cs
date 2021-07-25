using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class RequestDataCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            LoginRequest packetType = (LoginRequest) inc.ReadByte();

            switch (packetType)
            {
                case LoginRequest.ReqCharacters:
                    new ReceiveCharactersCmd().Read(inc);
                    break;
                default:
                    Console.WriteLine("Something went wrong in `RequestDataCmd.cs` On Client");
                    break;
            }
        }
    }
}