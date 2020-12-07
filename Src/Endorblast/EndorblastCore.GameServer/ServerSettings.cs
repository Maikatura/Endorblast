using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.GameServer
{
    class ServerSettings
    {
        private const int TICKS_PER_SEC = 30;
        private const float MS_PER_TICK = 1000f / TICKS_PER_SEC;


        public static float MSPERTICK()
        {
            return MS_PER_TICK;
        }

    }
}
