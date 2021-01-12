using System;
using Endorblast.Lib.Enums;
using Lidgren.Network;

namespace Endorblast.Lib.Network
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