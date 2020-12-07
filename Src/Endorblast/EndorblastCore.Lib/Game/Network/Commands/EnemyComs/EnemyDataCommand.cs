using Lidgren.Network;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Enums;

namespace EndorblastCore.Lib.Network
{
    class EnemyDataEvent : EventArgs
    {
        public int EnemyId;
        public Vector2 position;
        public DataTypePacket DataType;

        public StatType StatType;
        public float BaseValue;
        public float BonusValue;

        EnemyDataEvent(int enemyId, DataTypePacket dataType)
        {
            EnemyId = enemyId;
            DataType = dataType;
        }

        public EnemyDataEvent(int enemyId, DataTypePacket dataType, Vector2 position) : this(enemyId, dataType)
        {
            this.position = position;
            DataType = dataType;
        }

        public EnemyDataEvent(int enemyId, DataTypePacket dataType, StatType statType, float baseValue, float bonusValue) : this(enemyId, dataType)
        {
            StatType = statType;
            BaseValue = baseValue;
            BonusValue = bonusValue;
        }

    }

    class EnemyDataCommand : NetCommand
    {
        //static event EventHandler<EnemyDataEvent> _Event;
        //public static event EventHandler<EnemyDataEvent> Event
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
            var dataType = (DataTypePacket)msg.ReadByte();
            int enemyId = msg.ReadInt32();
        }
    }
}
