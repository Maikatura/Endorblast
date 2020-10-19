using EndorblastServer.Server.Game.Map;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{

    class WorldCharacterChangeMapEvent
    {
        public MapType mapType;
        public SvCharacter character;

        WorldCharacterChangeMapEvent(MapType mapType, SvCharacter character)
        {
            this.mapType = mapType;
            this.character = character;
        }
    }


    class WorldCharacterChangeMapCommand : NetCommand
    {
        static event EventHandler<WorldCharacterChangeMapEvent> _Event;
        public static event EventHandler<WorldCharacterChangeMapEvent> Event
        {
            add
            {
                _Event = null;
                _Event += value;
            }
            remove
            {
                _Event -= value;
            }
        }

        

        public static void Send(NetConnection con)
        {
            var msg = ServerManager.Instance.Server.CreateMessage();
            
        }

    }
}
