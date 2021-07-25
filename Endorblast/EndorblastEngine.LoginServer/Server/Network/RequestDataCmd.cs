using System;
using System.Threading.Channels;
using Endorblast.DBase;
using Endorblast.Library.Enums;
using EndorblastEngine.LoginServer.Login.Handle;
using EndorblastEngine.LoginServer.Network.Messages;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class RequestDataCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            LoginRequest type = (LoginRequest) inc.ReadByte();

            switch (type)
            {
                case LoginRequest.ReqCharacters:
                    new LoadCharactersCmd().Read(inc);
                    break;
                
                default:
                    Console.WriteLine("Something went wrong in `RequestDataCmd.cs`. FIX IT!");
                    break;
            }
        }
    }
}