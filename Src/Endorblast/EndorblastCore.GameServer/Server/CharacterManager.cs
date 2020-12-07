using System.Collections.Generic;
using EndorblastCore.Lib;
using EndorblastCore.Lib.Network;
using Lidgren.Network;

namespace EndorblastCore.GameServer.Server
{
    public class CharacterManager
    {
        static CharacterManager instance = new CharacterManager();
        public static CharacterManager Instance => instance;
        
        public int currentPlayerId = 0;
        
        public List<ServerCharacter> Characters = new List<ServerCharacter>();

        public List<NetConnection> GetConnections(string chName)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.Name != chName)
                    list.Add(p.connection);

            return list;
        }

        public ServerCharacter GetConnection(NetConnection con)
        {
            foreach (var p in Characters)
                if (con == p.connection)
                    return p;

            return null;
        }
        
        public List<NetConnection> GetConnections(int worldId)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.WorldID != worldId)
                    list.Add(p.connection);


            return list;
        }
        
        public List<NetConnection> GetConnections()
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                list.Add(p.connection);


            return list;
        }
        
        public List<ServerCharacter> GetPlayers()
        {
            var list = new List<ServerCharacter>();

            foreach (var p in Characters)
                list.Add(p);


            return list;
        }
        
    }
}