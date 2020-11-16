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
            float time = msg.ReadFloat();
            float x = msg.ReadFloat();
            float y = msg.ReadFloat();

            var ch = CharacterManager.Instance.GetConnection(worldID);

            if (ch == null)
                return;

            var bufferThing = new MoveBuffer()
            {
                state = state,
                time = time,
                X = x,
                Y = y
            };

            ch.currentBuffer = bufferThing;
            ch.bufferMove.Add(bufferThing);
        }


        public void Send(PlayerMoveState state)
        {
            NetOutgoingMessage outmsg = NetworkManager.Instance.CreateCharacterMessage();
            outmsg.Write((byte)CharacterPacket.Data);
            outmsg.Write((byte)CharacterDataType.Position);
            outmsg.Write((byte)state);
            outmsg.Write(Time.TotalTime);

            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.Unreliable);
        }

    }
}
