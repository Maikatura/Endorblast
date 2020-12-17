using System;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.Lib.Network
{
    public class LoginDataCmd
    {

        public void Read(NetIncomingMessage inc)
        {
            LoginPacket packet = (LoginPacket) inc.ReadByte();

            switch (packet)
            {
                case LoginPacket.LoginSuccess:
                    Console.WriteLine("LOL");
                    break;
                case LoginPacket.LoginFailed:
                    
                    break;
                
            }
        }
        
    }
}