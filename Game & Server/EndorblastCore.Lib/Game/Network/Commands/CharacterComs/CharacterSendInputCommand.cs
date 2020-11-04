using EndorblastCore.Lib.Enums;
using Lidgren.Network;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EndorblastCore.Lib.Game.Network
{
    public class PositionBuffer
    {
        public float x;
        public float y;
        public float velX;
    }

    class CharacterSendInputCommand
    {
        

        public void Read(NetIncomingMessage msg)
        {
            if (NetworkManager.Instance.State != NetworkState.InGame)
                return;

            int worldID = msg.ReadInt32();
            PlayerMoveState state = (PlayerMoveState)msg.ReadByte();
            //float time = msg.ReadFloat();

            //Console.WriteLine(time);
            //Console.WriteLine(DateTime.Now.Ticks);
            
            var ch = CharacterManager.Instance.GetConnection(worldID);

            if (ch == null)
                return;

            ch.moveState = state;
        }


        public void Send(PlayerMoveState state)
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);
            outmsg.Write((byte)state);

            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
