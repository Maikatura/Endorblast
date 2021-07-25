using System;
using Endorblast.DBase;
using Endorblast.Library.Enums;

namespace EndorblastEngine.LoginServer.Login.Messages
{
    public class LoginMessage
    {

        
        public LoginStatus TestLogin(string username, string password)
        {
            bool userExist = new AccountExistCmd().UserExist(username);

            if (!userExist)
                return LoginStatus.Failed;
            
            int accountID = new AccountIDCmd().GetAccountID(username);

            if (accountID == 0)
                return LoginStatus.ServerError;
            
            bool rightPassword = new AccountPasswordCheckCmd().IsPasswordRight(accountID, password);

            if (!rightPassword)
                return LoginStatus.Failed;
            
            return LoginStatus.Success;
        }
        
        
        
    }
}