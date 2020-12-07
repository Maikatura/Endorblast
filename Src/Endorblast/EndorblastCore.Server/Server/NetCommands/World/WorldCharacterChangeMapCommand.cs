using EndorblastCore.Server;
using Lidgren.Network;
using System;
using EndorblastCore.Lib;

namespace EndorblastCore.Server.NetCommands
{

    class WorldCharacterChangeMapEvent
    {
        public MapType mapType;
        public BasePlayer character;

        WorldCharacterChangeMapEvent(MapType mapType, BasePlayer character)
        {
            this.mapType = mapType;
            this.character = character;
        }
    }


    class WorldCharacterChangeMapCommand : NetCommand
    {
        //static event EventHandler<WorldCharacterChangeMapEvent> _Event;
        //public static event EventHandler<WorldCharacterChangeMapEvent> Event
        //{
        //    add
        //    {
        //        _Event = null;
        //        _Event += value;
        //    }
        //    remove
        //    {
        //        _Event -= value;
        //    }
        //}

        

        public static void Send(NetConnection con)
        {
            var msg = ServerManager.Instance.Server.CreateMessage();
            
        }

    }
}
