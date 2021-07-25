using Lidgren.Network;

namespace EndorblastEngine.LoginServer.Network
{
    public abstract class LoginNetCommand
    {
        protected static LoginServerManager netmana = LoginServerManager.Instance;
        protected static NetPeer server = LoginServerManager.Server;
    }
}