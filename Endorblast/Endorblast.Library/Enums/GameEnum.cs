namespace Endorblast.Library.Enums
{
    #region Packets
    
    
    #region Game Data
    
    public enum GamePacket{
        Token,
        Logic,
        Info,
        Data,
        MapData,
    }

    public enum GameLogicPacket
    {
        RequestCharacter,
        RequestJoinGame,
    }

    public enum GameDataPacket
    {
        
    }
    
    
    
    
    
    
    #endregion
    
    
    
    #endregion
    
    public enum SceneState
    {
        DemoScene,
        SplashScreen,
        LoginMenu,           // Login screen
        ServerMenu,
        RegisterMenu,       // Where you register youself
        CharacterSelection,
        CharacterCreation,
        PlayingState,       // Player is ingame an running the full game
        LoadingState,
    }
    
    
}