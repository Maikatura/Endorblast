namespace Endorblast.Lib.Network
{
    public class ServerSettings
    {
        // ---- Master Server Settings ----
        public static string host = "localhost"; // IP of Master
        public static int masterServerPort = 5555;
        public static int maxConnections = 1000;
        
        // ---- Game Server Settings Stuff ----
        public static int apiServerPort = 5556;
        public static int loginServerPort = 5557;
        public static int gameServerPort = 5558;
    }
}