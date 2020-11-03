using Lidgren.Network;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;
using Nez;
using Endorblast.Lib.Skills;

namespace EndorblastServer.Server.NetCommands
{
    


    public class CharacterSkillCastCommand : NetCommand
    {
        public void Read(NetIncomingMessage inc)
        {
            SkillType type = (SkillType)inc.ReadByte();
            float dir = inc.ReadFloat();

            var player = CharacterManager.Instance.GetConnection(inc.SenderConnection);

            if (player == null)
                return;

            player.DoSkill(type, player, dir);
            Send(type, player.WorldID, dir);
        }


        public void Send(SkillType type, int pid, float dir)
        {
            NetOutgoingMessage outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.SkillCast);

            outmsg.Write((byte)type);
            outmsg.Write(pid);
            outmsg.Write(dir);

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }


    }
}
