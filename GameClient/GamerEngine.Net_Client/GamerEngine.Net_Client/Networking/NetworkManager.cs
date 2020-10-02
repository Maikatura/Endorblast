using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;

namespace GamerEngineNet_Client
{
    public class NetworkManager
    {

        

        public int connectionID;

        public int GetPlayerConID()
        {
            return this.connectionID;
        }

        public void SetPlayerConID(int connectionID)
        {
           this.connectionID = connectionID;
        }

    }
}
