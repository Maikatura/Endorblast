using System;
using Endorblast.LoginServer.Login;

namespace Endorblast.LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginServerScript.Instance.Start();
        }
    }
}
