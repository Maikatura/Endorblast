using Endorblast.Lib.Enums;
using Endorblast.Lib.Game.Network;
using Lidgren.Network;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Network
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
        //static event EventHandler<CharacterDataPositionEvent> _PositionEvent;
        //public static event EventHandler<CharacterDataPositionEvent> PositionEvent
        //{
        //    add
        //    {
        //        _PositionEvent = null;
        //        _PositionEvent += value;
        //    }
        //    remove
        //    {
        //        _PositionEvent -= value;
        //    }
        //}

        public void Read(NetIncomingMessage msg)
        {
            var dataType = (CharacterDataType)msg.ReadByte();

            switch (dataType)
            {
                case CharacterDataType.OnlineCharacters:
                    break;
                case CharacterDataType.Position:
                    new CharacterSendInputCommand().Read(msg);
                    break;
                case CharacterDataType.SkillCast:
                    new CharacterSkillCastCommand().Read(msg);
                    break;
                default:
                    Console.WriteLine("THE DATA THAT GOT HERE DOESN'T EXIST!");
                    break;
            }
        }

        public void Send(CharacterDataType type, BasePlayer player)
        {
            // var outmsg = NetworkManager.Instance.CreateCharacterMessage();
            // outmsg.Write((byte)CharacterPacket.Data);
            // outmsg.Write((byte)type);
            //
            // switch (type)
            // {
            //     case CharacterDataType.OnlineCharacters:
            //         break;
            //     case CharacterDataType.Position:
            //         
            //
            //         
            //         break;
            //     default:
            //         break;
            // }

        }
    }
}
