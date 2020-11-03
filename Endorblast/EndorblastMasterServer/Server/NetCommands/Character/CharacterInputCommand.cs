using Endorblast;
using Endorblast.Lib;
using Endorblast.Lib.Enums;
using Lidgren.Network;
using Nez;
using Org.BouncyCastle.Bcpg;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
{
    public class CharacterInputCommand
    {



        public void Read(NetIncomingMessage msg)
        {
            var input = new KeyboardInput();

            input.MoveLeft = msg.ReadBoolean();
            input.MoveRight = msg.ReadBoolean();
            input.isSprinting = msg.ReadBoolean();
            input.isJumping = msg.ReadBoolean();

            var player = CharacterManager.Instance.GetConnection(msg.SenderConnection);

            if (player == null)
                return;


            if (!player.GetComponent<KeyboardInput>().OldPosIsPos)
            {
                player.GetComponent<KeyboardInput>().SetInputs(input);
                Send(input, player.WorldID);
            }
        }

        public void Send(KeyboardInput input, int WorldID)
        {
            var outmsg = ServerManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);

            outmsg.Write(WorldID);

            outmsg.Write(input.MoveLeft);
            outmsg.Write(input.MoveRight);
            outmsg.Write(input.isSprinting);
            outmsg.Write(input.isJumping);

            ServerManager.Instance.Server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
