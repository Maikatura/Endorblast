using System;
using Endorblast.Library.Enums;
using Endorblast.Library.GUI.ErrorMessageTypes;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.None
{
    public class ErrorRecieveCmd : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            var messageType = (ErrorCode) inc.ReadByte();

            switch (messageType)
            {
                case ErrorCode.Error0100_ServerMaintenance:
                    break;
                case ErrorCode.Error0101_ServerError:
                    break;
                case ErrorCode.Error0102_LoginError:
                
                    break;
                case ErrorCode.Error0200_TokenFailed:
                    new ErrorOkUI().ShowError("Your login failed!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}