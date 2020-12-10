using System;
using System.Collections.Generic;
using EndorblastCore.Lib;

namespace EndorblastCore.GameServer.Server
{

    public class ServerSnapshotInfo
    {
        public TimeSpan snapshotTime;
        public ServerCharacter[] characters;
    }
    
    
    public class ServerSnapshot
    {


        private static List<ServerSnapshotInfo> serverSnapshots = new List<ServerSnapshotInfo>();

        public static List<ServerSnapshotInfo> GetSnapShots()
        {
            return serverSnapshots;
        }

        public static void AddSnapshot()
        {
            if (GetSnapShots().Count >= 128)
            {
                RemoveFirstSnapshot();
            }
            
            // TODO : Fix snapshot system
            GetSnapShots().Add(new ServerSnapshotInfo());
            
        }

        public static void RemoveFirstSnapshot()
        {
            GetSnapShots().RemoveAt(0);
        }
        
    }
}