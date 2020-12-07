using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib.Enums
{




    public enum PacketType
    {
        Map,
        Character,
        Account,
        World,

    }

    public enum DataTypePacket
    {
        Position,
    }

    public enum MapType
    {
        Town,
        Snowlands,
    }

    public enum StatType
    {
        Tank,

    }



    public enum WorldPacket
    {
        Data,
        WorldEnter,
        WorldExit,
        WorldChange,
        EnemySpawn,
        EnemyDeath,
    }

    public enum CharacterDataType
    {
        OnlineCharacters,
        Position,
        SkillCast
    }

    public enum CharacterPacket
    {
        Data,
        List,
        Chat,
        EnemyDamaged,
    }

    public enum EnemyType
    {
        Skeleton,
        Zombie,
        Hentai,
    }
}
