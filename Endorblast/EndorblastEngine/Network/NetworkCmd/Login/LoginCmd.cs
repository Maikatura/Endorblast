using System;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Endorblast.Library.GUI.ErrorMessageTypes;
using Endorblast.LoginServer.Data;
using EndorblastEngine.Network.NetworkCmd.Master;
using Lidgren.Network;
using Nez;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class LoginCmd : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            LoginStatus type = (LoginStatus)inc.ReadByte();
            
            switch (type)
            {
                case LoginStatus.ServerMaintenance:
                    Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCode.Error0100_ServerMaintenance));
                    break;
                case LoginStatus.ServerError:
                    Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCode.Error0101_ServerError));
                    break;
                case LoginStatus.Failed:
                    Console.WriteLine("Wrong Information.");
                    new ErrorOkUI().ShowError(ErrorCodes.GetErrorMessage(ErrorCode.Error0102_LoginError));
                    break;
                case LoginStatus.Success:
                    Console.WriteLine("Login Successful.");
                    
                    var username = inc.ReadString();
                    var token = inc.ReadString();
                    
                    GameManager.SetUsername = username;
                    GameManager.SetLoginToken = token;
                    
                    //new RequestCharactersCmd().Send(GameManager.GetLoginToken);
                    
                    new AskToJoinGameCmd().Send(username, token);

                    break;
                default:
                    Console.WriteLine("## Error: reading login try type, that login fail/success does not exist");
                    break;
            }

        }

        


        
    }
}