using Endorblast.MasterServer;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class MasterNet
    {
        protected static MasterServerScript netmana = MasterServerScript.Instance;
        protected static NetPeer server = MasterServerScript.Instance.Server;
    }
}