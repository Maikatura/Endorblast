namespace Endorblast.Library.Enums
{
    


    #region World Data

    #region Character Data

    public enum CharacterDataType
    {
        OnlineCharacters,
        Position,
        SkillCast
    }
    
    public enum CharacterSendPacket
    {
        SkillCast,
        Data,
        List
    }
    
    public enum CharacterPacket
    {
        Data,
        List,
        Chat,
        EnemyDamaged,
    }

    #endregion

    #region Map Data
    
    public enum MapPacket
    {
        Data,
        WorldEnter,
        WorldExit,
        WorldChange,
        EnemySpawn,
        EnemyDeath,
    }
    

    #endregion
    
    #endregion
}