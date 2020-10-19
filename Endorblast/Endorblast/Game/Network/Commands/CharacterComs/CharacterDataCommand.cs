using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Network.Commands
{

    public class CharacterDataPositionEvent : EventArgs
    {
        public int x, y;
        public int worldid;

        public CharacterDataPositionEvent(int x, int y, int wid)
        {
            this.x = x;
            this.y = y;
            this.worldid = wid;
        }
    }

    public class CharacterDataCommand : NetCommand
    {
        static event EventHandler<CharacterDataPositionEvent> _PositionEvent;
        public static event EventHandler<CharacterDataPositionEvent> PositionEvent
        {
            add
            {
                _PositionEvent = null;
                _PositionEvent += value;
            }
            remove
            {
                _PositionEvent -= value;
            }
        }

        public void Read(NetIncomingMessage msg)
        {
            var dataType = (CharacterDataType)msg.ReadByte();

            switch (dataType)
            {
                case CharacterDataType.OnlineCharacters:

                    break;
                case CharacterDataType.Position:
                    int worldId = msg.ReadInt32();
                    int x = msg.ReadInt32();
                    int y = msg.ReadInt32();
                    _PositionEvent?.Invoke(this, new CharacterDataPositionEvent(x, y, worldId));
                    break;
                default:
                    Console.WriteLine("THE DATA THAT GOT HERE DOESN'T EXIST!");
                    break;
            }
        }

        public static void Send(CharacterDataType type, params object[] data)
        {
            var outmsg = NetworkManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)type);
        }
    }
}
