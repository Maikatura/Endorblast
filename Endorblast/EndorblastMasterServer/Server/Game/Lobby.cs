using EndorblastServer.Server.Game.Map;
using Lidgren.Network;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    public enum LobbyType
    {
        World,
        Town
    }

    public class Sessions
    {
        public LobbyType type;
        static int _lobbyId = 0;
        public int lobbyId;

        bool inited;

        public MapManager mapManager;

        public List<BasePlayer> characters = new List<BasePlayer>();

        public List<NetConnection> Connections()
        {
            var list = new List<NetConnection>();
            foreach (var ch in characters)
            {
                list.Add(ch.connection);
            }
            return list;
        }

        public List<NetConnection> Connections(int playerId)
        {
            var list = new List<NetConnection>();
            foreach (var ch in characters)
                if (ch.WorldID != playerId)
                    list.Add(ch.connection);

            return list;
        }

        public Sessions()
        {
            lobbyId = _lobbyId;
            _lobbyId += 1 % 123456;
        }

        public Sessions(params BasePlayer[] chars) : this()
        {
            //mapManager = new MapManager();
            MapType mapType;

            if (type == LobbyType.Town)
            {
                mapType = MapType.Town;
                //mapManager.GenerateMap(lobbyId, mapType);
            }
            else
            {
                mapType = MapType.Snowlands;
                //mapManager.GenerateMap(lobbyId, mapType);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
                //WorldDataCommand.Send(c.connection, mapType, mapManager.map.Width, mapManager.map.Height);
                AddPlayer(c);
            }
        }

        public virtual void Init()
        {
            

            inited = true;
        }

        public virtual void AddPlayer(BasePlayer character)
        {
            //CharacterListCommand.Send(character.connection, character.WorldID, characters);
            characters.Add(character);
            character.currentLobbyId = lobbyId;
            //WorldCharacterEnterCommand.Send(character.ToLibCharacter(), Connections(character.WorldID));
        }

        public virtual void RemovePlayer(int playerId)
        {
            //WorldRemoveCharacterCommand.Send(playerId, Connections());
            //characters.RemoveFirst(x => x.WorldID == playerId);
            Console.WriteLine($"Lobby#{lobbyId} - Removed player {playerId}");
        }

        public virtual void Update()
        {
            if (!inited)
            {
                Init();
                return;
            }
        }
    }

    public class TownLobby : Sessions
    {
        public TownLobby() : base()
        {
            type = LobbyType.Town;
        }

        public override void Update()
        {
            base.Update();
        }
    }

    public class WorldLobby : Sessions
    {
        //public EnemyManager eManager;
        float lifeTime = 3f;
        public bool IsAlive => lifeTime > 0f;

        public WorldLobby(params BasePlayer[] chars) : base(chars)
        {
            type = LobbyType.World;

            /*
            if (eManager == null)
            {
                eManager = new EnemyManager(lobbyId);
            }
            */
        }

        public override void Init()
        {
            base.Init();
        }

        public override void AddPlayer(BasePlayer character)
        {
            //if (eManager == null)
            //    eManager = new EnemyManager(lobbyId);

            base.AddPlayer(character);
            //EnemyListCommand.Send(eManager.List, character.connection);
        }

        public override void Update()
        {
            base.Update();
            if (characters.Count <= 0)
                lifeTime -= Time.DeltaTime;
            else
                lifeTime = 10f;

            // eManager.Update(characters);
        }
    }
}
