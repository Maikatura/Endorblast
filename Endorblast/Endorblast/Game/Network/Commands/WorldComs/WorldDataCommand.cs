using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Network.Commands
{
    class WorldDataEvent : EventArgs
    {
        public MapType mapType;
        public int Width;
        public int Height;
        public WorldDataEvent(MapType maptype, int width, int height)
        {
            this.mapType = mapType;
            Width = width;
            Height = height;
        }
    }

    class WorldDataCommand : NetCommand
    {

        static event EventHandler<WorldDataEvent> _Event;
        public static event EventHandler<WorldDataEvent> Event
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

        public void Read(NetIncomingMessage msg)
        {
            var mapType = (MapType)msg.ReadByte();
            var width = msg.ReadInt32();
            var heigth = msg.ReadInt32();

            _Event?.Invoke(this, new WorldDataEvent(mapType, width, heigth));
        }

    }
}
