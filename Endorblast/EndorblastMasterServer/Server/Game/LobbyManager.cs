using EndorblastServer.Server.Game.Map;
using Lidgren.Network;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    class LobbyManager
    {
        //static LobbyManager instance = new LobbyManager();
        //public static LobbyManager Instance => instance;

        public List<WorldLobby> worldLobbies;
        public Sessions townLobby;

        public List<StaticCharacter> CharacterQueue = new List<StaticCharacter>();

        public LobbyManager()
        {
            //townLobby = new TownLobby();
            //worldLobbies = new List<WorldLobby>();
            Console.WriteLine("Town lobby created");

            WorldCharacterChangeMapCommand.Event += WorldCharacterChangeMapCommand_Event;
        }

        private void WorldCharacterChangeMapCommand_Event(object sender, WorldCharacterChangeMapEvent e)
        {
            var character = e.character;
            var oldLobby = GetLobby(character.currentLobbyId);


            oldLobby.RemovePlayer(character.WorldID);

            if (e.mapType == MapType.Snowlands)
            {
                if (worldLobbies.Count == 0)
                    CreateLobby(character);
                else
                {
                    worldLobbies[0].AddPlayer(character);
                }
            }
            else
            {
                townLobby.AddPlayer(character);
            }
        }

        public List<NetConnection> GetConnections(int lobbyId, int execptPlayerId = -1)
        {
            var lobby = GetLobby(lobbyId);
            if (lobby != null)
                return lobby.Connections(execptPlayerId);
            return null;
        }

        public Sessions GetLobby(int lobbyId)
        {
            if (lobbyId == 0)
                return townLobby as TownLobby;

            var lobby = worldLobbies.FirstOrDefault(x => x.lobbyId == lobbyId);

            if (lobby != null)
                return lobby as WorldLobby;

            Console.WriteLine("## ERROR LOBBY WAS NULL -- LobbyManager.GetLobby() id:" + lobbyId);
            return lobby;
        }

        public Sessions CreateLobby(params BasePlayer[] characters)
        {
            var lobby = new WorldLobby(characters);
            worldLobbies.Add(lobby);

            Console.WriteLine("####################");
            Console.WriteLine($"Lobby created ID#{lobby.lobbyId}");

            for (int i = 0; i < lobby.characters.Count; i++)
            {
                Console.WriteLine($"# {lobby.characters[i].Name}");
            }

            Console.WriteLine($"#-- {lobby.characters.Count} in lobby --#");
            Console.WriteLine("####################");

            return lobby;
        }

    }

}
