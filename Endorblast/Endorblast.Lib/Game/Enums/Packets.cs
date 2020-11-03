using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Enums
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
        CharacterEnter,
        CharacterExit,
        EnemySpawn,
        EnemyDeath,
    }

    public enum CharacterDataType
    {
        OnlineCharacters,
        Position
    }

    public enum CharacterPacket
    {
        SkillCast,
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
