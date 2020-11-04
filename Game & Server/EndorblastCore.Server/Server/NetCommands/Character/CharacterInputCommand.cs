using Endorblast;
using EndorblastCore.Lib;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.Game.Network;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using MySql.Data.MySqlClient.Memcached;
using Nez;
using Org.BouncyCastle.Bcpg;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Server.NetCommands
{
    public class CharacterInputCommand
    {


        public void Read(NetIncomingMessage msg)
        {
            PlayerMoveState state = (PlayerMoveState)msg.ReadByte();

            var player = CharacterManager.Instance.GetConnection(msg.SenderConnection);

            if (player == null)
                return;

            if (player.moveState != state)
            {
                player.moveState = state;
                Send(state, player.WorldID);
            }
        }

        public void Send(PlayerMoveState state, int WorldID)
        {
            var outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);
            outmsg.Write(WorldID);

            outmsg.Write((byte)state);

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
