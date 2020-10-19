using Endorblast.GamePlay;
using Endorblast.GamePlay.Items;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Network.Commands
{
    public class CharacterSkillCastEvent : EventArgs
    {
        public float direction;
        public SkillType skillType;
        public int pid;

        public CharacterSkillCastEvent(SkillType skillType,int id, float direction)
        {
            this.skillType = skillType;
            this.pid = id;
            this.direction = direction;
        }
    }

    public class CharacterSkillCastCommand : NetCommand
    {
        static event EventHandler<CharacterSkillCastEvent> _Event;
        public static event EventHandler<CharacterSkillCastEvent> Event
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
            int pid = msg.ReadInt32();
            SkillType skillType = (SkillType)msg.ReadByte();
            float dir = msg.ReadFloat();
            _Event?.Invoke(this, new CharacterSkillCastEvent(skillType, pid, dir));
        }

        public static void Send(SkillType type, float rotation)
        {
            var msg = NetworkManager.Instance.CreateCharacterMessage();
            msg.Write((byte)CharacterPacket.SkillCast);
            msg.Write((byte)type);
            msg.Write(rotation);

            NetworkManager.Instance.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
