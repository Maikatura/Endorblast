using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    public enum NetworkState
    {
        None,
        LoggingIn,
        InGame,
    }

    public enum EnemyType
    {

    }

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

    public enum CharacterPacket
    {
        SkillCast,
        Data,
        List
    }

    public enum AccountPacket
    {
        LoginState,
        LoginMePlz,
    }

    public enum WorldPacket
    {
        CharacterEnter,
        CharacterLeft,
    }

    public enum CharacterDataType
    {
        OnlineCharacters,
        Position
    }


    public enum SkillType
    {
        Basic,
        Dash,
    }

}
