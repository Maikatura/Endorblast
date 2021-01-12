using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Network
{
    public abstract class NetCommand
    {

        protected static NetworkManager netmana = NetworkManager.Instance;
        protected static NetClient client = NetworkManager.Instance.client;

        

    }
}
