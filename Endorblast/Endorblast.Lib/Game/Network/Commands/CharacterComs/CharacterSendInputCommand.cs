using Endorblast.Lib.Enums;
using Lidgren.Network;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Game.Network
{
    class CharacterSendInputCommand
    {

        public void Read(NetIncomingMessage msg)
        {
            if (NetworkManager.Instance.State != NetworkState.InGame)
                return;

            int worldID = msg.ReadInt32();

            var input = new KeyboardInput();

            input.MoveLeft = msg.ReadBoolean();
            input.MoveRight = msg.ReadBoolean();
            input.isSprinting = msg.ReadBoolean();
            input.isJumping = msg.ReadBoolean();

            var ch = CharacterManager.Instance.GetConnection(worldID);

            if (ch == null)
                return;

            ch.GetComponent<KeyboardInput>().SetInputs(input);
            
        }


        public void Send(KeyboardInput input)
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);

            

            outmsg.Write(input.MoveLeft);
            outmsg.Write(input.MoveRight);
            outmsg.Write(input.isSprinting);
            outmsg.Write(input.isJumping);


            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
