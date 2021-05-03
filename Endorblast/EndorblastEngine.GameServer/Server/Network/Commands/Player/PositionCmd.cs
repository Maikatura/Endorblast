using System;
using Endorblast.GameServer.Server;
using Endorblast.Library;
using Endorblast.Library.Entities;
using Lidgren.Network;
using Endorblast.Library.Enums;

namespace Endorblast.GameServer.NetworkCmd
{
    public class PositionCmd : NetCmd
    {
        
        public void Receive(NetIncomingMessage inc)
        {
            float x = inc.ReadFloat();
            float y = inc.ReadFloat();
            MoveState state = (MoveState)inc.ReadByte();

            var player = MapManager.Instance.GetPlayer(inc.SenderConnection);

            if (player == null)
                return;
            
            Send(player.WorldID, x, y, state);

        }
        

        private void Send(int worldId, float x, float y, MoveState state)
        {
            var list = MapManager.Instance.GetConnections(worldId);

            if (list == null)
                return;

            var outmsg = GameServerScript.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);
            
            outmsg.Write(x);
            outmsg.Write(y);
            outmsg.Write((byte)state);

            GameServerScript.Instance.Server.SendMessage(outmsg, list, NetDeliveryMethod.ReliableOrdered,0);
        }
        
        
        
        
    }
}