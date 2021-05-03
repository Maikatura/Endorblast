using System;
using System.Collections.Generic;
using Endorblast.GameServer.Entities;
using Endorblast.Library;
using Endorblast.Library.Network;
using Lidgren.Network;
using Microsoft.Xna.Framework;

namespace Endorblast.GameServer.Server
{
    public class CharacterManager
    {
        

        public int currentPlayerId = 0;
        
        public List<Player> Characters = new List<Player>();

        public CharacterManager()
        {
            currentPlayerId = 0;


            ConsoleHelper.WriteLine("## CharacterManager - Initialized", ServerErrors.Error);
        }
        
        public void Update()
        {
            foreach (var player in Characters)
            {
                player.Update();
            }
        }
        
        
        public List<NetConnection> GetConnections(string chName)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.AccountName != chName)
                    list.Add(p.connection);

            return list;
        }

        public Player GetConnection(NetConnection con)
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
        
        public List<Player> GetPlayers()
        {
            var list = new List<Player>();

            foreach (var p in Characters)
                list.Add(p);


            return list;
        }

        public Player AddPlayer(Player player)
        {
            Characters.Add(player);
            return player;
        }
        
    }
}