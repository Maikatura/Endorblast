using Endorblast.GameServer.Server;
using Endorblast.Library.Enums;
using Lidgren.Network;
using Microsoft.VisualBasic;

namespace Endorblast.GameServer.NetworkCmd
{
    public class SkillCmd : NetCmd
    {
        public override void Read(NetIncomingMessage inc)
        {

            ActionType actionType = (ActionType) inc.ReadByte();
            float dir = inc.ReadFloat();
            
            var player = MapManager.Instance.GetPlayer(inc.SenderConnection);

            if (player == null)
                return;
            
            // Send(player.WorldID, player.playerID, dir, actionType);
        }
        

        public void Send(int worldId, int playerID, float dir, ActionType action)
        {
            var list = MapManager.Instance.GetConnections(worldId);
            
            if (list == null)
                return;
            
            // var outmsg = GameServerScript.Instance.CreateCharacterMessage();
            //
            // outmsg.Write(worldId);
            // outmsg.Write(playerID);
            // outmsg.Write(dir);
            // outmsg.Write((byte)action);

        }
    }
}