using System.Xml.Linq;
using EndorblastEngine.Network.NetworkCmd;
using Lidgren.Network;

namespace EndorblastEngine.Network
{
    public abstract class NetCommand
    {

        protected static NetworkManager netmana = NetworkManager.Instance;
        protected static NetClient client = NetworkManager.Instance.Client;
        

    }
}
