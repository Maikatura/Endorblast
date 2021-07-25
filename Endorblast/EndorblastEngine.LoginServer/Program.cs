using System;
using System.Net;
using Endorblast.Backend;
using Endorblast.Library.Enums;
using EndorblastEngine.LoginServer.Login.Messages;
using Lidgren.Network;


namespace EndorblastEngine.LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // new TokenGenerator().GenerateToken("zyro@123");
            
            LoginServerManager loginServer = new LoginServerManager();
            loginServer.Start(27541);
        }
    }
}