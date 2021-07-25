using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class NetCmd
    {

        protected GameServerScript netmana = GameServerScript.Instance;

        protected NetServer server = GameServerScript.Server;
        
        public virtual void Read(NetIncomingMessage inc) { }

        public virtual void Send() { }
        
    }
}