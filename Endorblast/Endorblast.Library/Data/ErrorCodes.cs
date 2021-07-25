using System;
using Endorblast.Library.Enums;

namespace Endorblast.LoginServer.Data
{
    public static class ErrorCodes
    {


        public static string GetErrorMessage(ErrorCode errorType)
        {
            string errorMessage = "";
            
            switch (errorType)
            {
                case ErrorCode.Error0100_ServerMaintenance:
                    errorMessage = "Error 0100 : Server Maintenance.";
                    break;
                case ErrorCode.Error0101_ServerError:
                    errorMessage = "Error 0101 : Server Error.";
                    break;
                case ErrorCode.Error0102_LoginError:
                    errorMessage = "Error 0102 : Login Error";
                    break;

            }

            return errorMessage;
        }
        
    }
}