namespace Endorblast.Lib.Game.Data
{
    public class GameServerInfo
    {


        public string serverName;
        public string ipAddress;
        public bool joinable;

        public GameServerInfo(string name, string ip)
        {
            serverName = name;
            ipAddress = ip;
            
            // TODO : Make if so you can join if server offline
            joinable = true;
        }

    }
}