using Endorblast.Lib.Enums;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
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
                    new CharacterInputCommand().Read(msg);
                    break;
                default:
                    Console.WriteLine("THE DATA THAT GOT HERE DOESN'T EXIST!");
                    break;
            }
        }

        public void Send(CharacterDataType type, Endorblast.Lib.BasePlayer player)
        {
            var outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)type);

            switch (type)
            {
                case CharacterDataType.OnlineCharacters:
                    break;
                case CharacterDataType.Position:
                    outmsg.Write(player.WorldID);
                    outmsg.Write(player.Transform.Position.X);
                    outmsg.Write(player.Transform.Position.Y);

                    Console.WriteLine(player.Transform.Position.X);
                    //var list = CharacterManager.Instance.GetConnections();

                    ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);

                    
                    break;
                default:
                    break;
            }
        }
    }
}
