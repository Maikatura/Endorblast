using System;
using System.Net;
using Endorblast.Backend;
using Endorblast.Library.Enums;
using Lidgren.Network;
using Nez.Tiled;

namespace Endorblast.GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            GameServerScript.Instance.Start(27545);

            while (true)
            {
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
