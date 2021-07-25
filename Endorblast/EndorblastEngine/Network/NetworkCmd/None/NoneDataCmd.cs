using System;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.None
{
    public class NoneDataCmd : NetCommand
    {
        public void Read(NetIncomingMessage inc)
        {
            var messageType = (NonePacket) inc.ReadByte();

            switch (messageType)
            {
                case NonePacket.ErrorCode:
                    new ErrorRecieveCmd().Read(inc);
                    break;
                case NonePacket.FailedMessage:
                    break;
                default:
                    Console.WriteLine("Something went wrong in `NoneDataCmd.cs` on Client");
                    break;
            }
        }
    }
}