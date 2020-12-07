using EndorblastCore.GameServer.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.GameServer
{
    class GameLogic
    {

        public static void Update()
        {
            // Update loop for everything that needs to be updated.
            MapManager.Instance.Update();
        }
        
        
       
    }
}
