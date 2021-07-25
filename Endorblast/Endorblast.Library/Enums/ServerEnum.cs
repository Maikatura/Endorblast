namespace Endorblast.Library.Enums
{
    

    

    #region Login
    
    
    public enum LoginStatus
    {
        Success,
        
        Failed,
        ServerMaintenance,
        ServerError
    }


    public enum LoginRequest
    {
        ReqCharacters,
        
    }

    #endregion
    
    #region Account/Character

    
    

    public enum EnemyType
    {
        Skeleton,
        Zombie,
        Hentai,
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
    
    public enum MasterServerMessageType
    {
        RegisterHost,
        RequestToLogin,
        RequestIntroduction,
        RequestGameServers,
        RequestToJoinGame,
        JoinGameServer,
        ClientRecieveServers,
    }
    

    public enum ServerTypes
    {
        None,
        Master,
        Login,
        Game,
        Chat,
        API,
        DATA,
    }

    public enum DataPacket
    {
        ERROR,
        Message,
    }

    public enum NonePacket
    {
        ErrorCode,
        FailedMessage,
    }
    
    

    #endregion
    
    

    #region Error Codes

    public enum ErrorCode
    {
        Error0100_ServerMaintenance,    // Server Maintenance
        Error0101_ServerError,          // Server Error
        Error0102_LoginError,           // Login Error
        
        
        Error0200_TokenFailed,          // Failed Token Check
    }

    #endregion
    
}