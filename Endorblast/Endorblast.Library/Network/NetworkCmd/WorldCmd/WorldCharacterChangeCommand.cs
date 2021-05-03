using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.Library.Network
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