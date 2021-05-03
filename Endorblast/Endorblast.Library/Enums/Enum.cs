namespace Endorblast.Library.Enums
{
    #region Player Class & Races

    
    /*
        Classes and Races Notes
            Note 1 
                If you plan to add new classes or abilities note that you need to:
                
                - Before:
                    - Make a prototype and play test before just making it. If its not FUN why do it.
                    - Find bugs and add it to github as a issue or fix it yourself.
                
                    
                - Production:
                    - Every sprite (item, abilities, outfits and icons) get done before new content update.
                    - Fixed most game breaking bugs that came with it.
                     
            Note 2
                
                
            
     */
   
    
    public enum PlayerClassTypes
    {
        /*  All classes are DPS :O
                Note - Based on World of Warcraft classes that I just combined or took elements from :)
                    Note 2 - I also have not copied any ability from WoW.
        */
        
        // Classes after for version 1.0
        
        Archer,         // (Archer)     DPS (Range)
        Warrior,        // (Warrior)    DPS (Close)
        Mage,           // (Mage)       DPS (Range)
        
        
        // Classes after for version 2.0 - If you read this of course I have removed it :-)
        
        
    }
    
    public enum PlayerRaceTypes
    {
        /*  All Races and race abilities :O
                Note - Passives are for the race only. (Please no abilities)
        */
        
        Human,          // (Warrior),   (Archer)    Race Ability: 1% more gold
        Cat,            // (Mage),      (Archer)    Race Ability: 5% more movement
        Demon,          // (Warrior)                Race Ability: 3% more damage
        Dragon          // (Warrior),   (Mage)      Race Ability: 3% more armor
        
    }
    
    #endregion
    
    #region Class Actions

    public enum MovementType
    {
        Idle,
        Walking,
        Slide,
        Jump,
    }
    
    public enum ActionType
    {
        Idle,
        Walking,
        Slide,
        Jump,

       
        // For if there are more classes later :)
        // Archer
        ArcherDefault,      // Archer //    Default -- First skill
        ArrowStrike,
        ShadowShot,
        CripplingStrike,
        
        // Warrior
        
        WarriorDefault,     // Warrior //   Default -- First skill
        
        // Mage
        MageDefault,        // Mage //      Default -- First skill
        
    }
    

    #endregion

    #region Maps
    
    public enum MapType
    {
        None,
        LoginMap,
        Town,
        Forest,
        Snowlands
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
    
    #endregion
    
    
    
    #region Account/Character

    public enum CharacterDataType
    {
        OnlineCharacters,
        Position,
        SkillCast
    }
    

    public enum EnemyType
    {
        Skeleton,
        Zombie,
        Hentai,
    }
   
    public enum AccountPacket
    {
        LoginState,
        LoginMePlz,
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
    
    #region Game States

    public enum NetworkState
    {
        None,
        LoggingIn,

        CharacterSelection,
        CharacterCreation,

        InGame,
    }

    #endregion
    
    #region Server

    public enum MasterPacket
    {
        RequestLoginAttempt,
        SendToGameServer,
        GetFromLoginServer,
        GetFromGameServer,
        RequestHostList,
        RegisterHost,
        RequestIntroduction,
        Login,
        
    }
    
    public enum MasterTypes
    {
        ConnectPacket,
        DisconnectPacket,
        TransferConnection,
        ReceiveConnection,
        RemoveConnection,
        AddConnection,
    }

    public enum GameServerTypes
    {
        Master,
        Login,
        
        World,
        Player,
        Enemy,
        
    }
    
    public enum LoginPacket
    {
        LoginRequest,
        LoginDisconnect,
        LoginSuccess,
        LoginFailed,
        GameServerInfo,
    }

    #endregion
}