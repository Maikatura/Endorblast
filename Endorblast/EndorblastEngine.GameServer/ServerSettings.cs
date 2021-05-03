using System;
using System.Collections.Generic;
using System.Text;

namespace Endorblast.GameServer
{
    class ServerSettings
    {
        
        // -- Server Update settings --
        private const int SEND_RATE = 10;       // Example: 10 is 10 times per second.
        
        
        private const int TICKS_PER_SEC = 30;
        private const float MS_PER_TICK = 1000f / TICKS_PER_SEC;


        public static float MSPERTICK()
        {
            return MS_PER_TICK;
        }

    }
}
