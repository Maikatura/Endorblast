using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class NetCmd
    {

        public virtual void Receive(NetIncomingMessage inc) { }

        public virtual void Send() { }
        
    }
}