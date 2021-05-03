using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;
using Nez;

namespace Endorblast.Library.Network
{
    public class CharacterSkillCastEvent : EventArgs
    {
        public float direction;
        public ActionType ActionType;
        public int pid;

        public CharacterSkillCastEvent(ActionType actionType,int id, float direction)
        {
            this.ActionType = actionType;
            this.pid = id;
            this.direction = direction;
        }
    }

    public class CharacterSkillCastCommand : NetCommand
    {
        //static event EventHandler<CharacterSkillCastEvent> _Event;
        //public static event EventHandler<CharacterSkillCastEvent> Event
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

        public void Read(NetIncomingMessage msg)
        {
            ActionType actionType = (ActionType)msg.ReadByte();
            int pid = msg.ReadInt32();
            float dir = msg.ReadFloat();

            var ch = CharacterManager.Instance.GetConnection(pid);

            if (ch == null)
                return;

            if (ch.HasComponent<MainPlayer>())
                return;

            ch.DoSkill(actionType, ch, dir);
        }

        public void Send(ActionType type, float rotation)
        {

            // var msg = NetworkManager.Instance.CreateCharacterMessage();
            // msg.Write((byte)CharacterPacket.Data);
            // msg.Write((byte)CharacterDataType.SkillCast);
            // msg.Write((byte)type);
            // msg.Write(rotation);
            //
            // NetworkManager.Instance.client.SendMessage(msg, NetDeliveryMethod.Unreliable);
        }
    }
}
