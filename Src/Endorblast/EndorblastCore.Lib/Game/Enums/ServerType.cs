namespace EndorblastCore.Lib.Enums
{
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
}