using System;
using EndorblastCore.Lib.Enums;
using Lidgren.Network;

namespace EndorblastCore.Lib.Network
{
    public class WorldCharacterChangeCommand : NetCommand
    {
        public void Read(NetIncomingMessage msg)
        {
            
        }
        
        public void Send()
        {
            Console.WriteLine("Not Implemented!");
        }
    }
}