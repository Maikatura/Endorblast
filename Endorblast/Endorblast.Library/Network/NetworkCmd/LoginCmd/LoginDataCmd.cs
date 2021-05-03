using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.Library.Network
{
    public class LoginDataCmd
    {

        public void Read(NetIncomingMessage inc)
        {
            LoginPacket packet = (LoginPacket) inc.ReadByte();

            switch (packet)
            {
                case LoginPacket.LoginSuccess:
                    new LoginSuccessfulCmd().Read(inc);
                    break;
                case LoginPacket.LoginFailed:
                    // TODO : Fix Error message on UI.
                    Console.WriteLine("Login Failed.");
                    break;
                
            }
        }
        
    }
}