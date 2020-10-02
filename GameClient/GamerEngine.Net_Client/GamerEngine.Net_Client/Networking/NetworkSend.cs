using KaymakNetwork.Network.Client;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerEngineNet_Client
{

    enum ClientPackets
    {
        CPing = 1,
        CSendInput,
        CJoinRequest,
    }

    internal static class NetworkSend
    {


        public static void SendHello(string msg)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ClientPackets.CPing);

            buffer.WriteString(msg);
            NetworkConfig.socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPlayerInputs(bool[] inputs)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ClientPackets.CSendInput);

            buffer.WriteInt32(inputs.Length);

            for (int i = 0; i < inputs.Length; i++)
            {
                buffer.WriteBoolean(inputs[i]);
            }

            NetworkConfig.socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();

        }

        public static void JoinGame()
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ClientPackets.CJoinRequest);

            NetworkConfig.socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

    }
}
