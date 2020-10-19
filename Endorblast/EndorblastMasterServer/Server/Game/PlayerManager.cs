using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
{
    public class PlayerManager
    {
        static PlayerManager instance = new PlayerManager();
        public static PlayerManager Instance => instance;


    }
}
