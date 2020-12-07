using System;
using EndorblastCore.Lib;
using Lidgren.Network;

namespace EndorblastCore.GameServer.Server.Commands.Player
{
    public class PositionCmd
    {
        
        public void Receive(NetIncomingMessage inc)
        {
            float x = inc.ReadFloat();
            float y = inc.ReadFloat();
            PlayerMoveState state = (PlayerMoveState)inc.ReadByte();

            var player = MapManager.Instance.GetPlayer(inc.SenderConnection);

            if (player == null)
                return;
            
            Send(player.WorldID, x, y, state);

        }
        

        public void Send(int worldId, float x, float y, PlayerMoveState state)
        {
            Console.WriteLine("Not working yet!");
        }
        
        
        
        
    }
}