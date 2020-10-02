using System;
using System.Collections.Generic;
using System.Text;

namespace MasterServer
{
    class ServerSettings
    {

        // -- Server Settings -- //
        public static int serverPort = 5555;
        public static int maxPlayers = 32;


        // -- Server Update rate -- //
        public const int TICKS_PER_SEC = 30;
        public const float MS_PER_TICK = 1000f / TICKS_PER_SEC;


    }
}
