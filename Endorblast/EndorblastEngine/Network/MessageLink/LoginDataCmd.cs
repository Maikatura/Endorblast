using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.MessageLink
{
    public class LoginDataCmd : NetCommand
    {


        public void Read(NetIncomingMessage inc)
        {
            LoginType type = (LoginType)inc.ReadByte();

            switch (type)
            {
                case LoginType.LoginRequest:
                    
                    break;
                default:
                    Console.WriteLine("Error Getting Login Packet Type");
                    break;
            }
        }
        
    }
}