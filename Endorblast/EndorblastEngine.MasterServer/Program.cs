using System;
using Endorblast.Backend;
using Endorblast.Library;

namespace Endorblast.MasterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterServerScript masterServer = new MasterServerScript();
            masterServer.Start(MasterSettings.Port);
            
            while (true)
            {
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
