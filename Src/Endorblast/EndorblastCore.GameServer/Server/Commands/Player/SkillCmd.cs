using EndorblastCore.Lib.Enums;
using Lidgren.Network;
using Microsoft.VisualBasic;

namespace EndorblastCore.GameServer.Server.Commands.Player
{
    public class SkillCmd
    {
        public void Receive(NetIncomingMessage inc)
        {
            SkillType skillType = (SkillType) inc.ReadByte();
            
            // Todo Remake to ushort instead.
            int playerID = inc.ReadInt32();
            float dir = inc.ReadFloat();
            
            


        }
        

        public void Send()
        {
            
        }
    }
}