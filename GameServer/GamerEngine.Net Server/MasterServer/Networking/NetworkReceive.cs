using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MasterServer
{

    enum ClientPackets
    {
        CPing = 1,
        CSendInput,
        CJoinRequest,
    }

    internal static class NetworkReceive
    {
        internal static void PacketRouter()
        {
            NetworkConfig.Socket.PacketId[(int)ClientPackets.CPing] = Packet_GetHello;
            NetworkConfig.Socket.PacketId[(int)ClientPackets.CSendInput] = Packet_GetPlayerInput;
            
        }


        private static void Packet_GetHello(int connectionID, ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);

            
            string msg = buffer.ReadString();
            Console.WriteLine(msg);

            GameManager.CreatePlayer(connectionID);

            buffer.Dispose();
        }

        private static void Packet_GetPlayerInput(int connectionID, ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);

            bool[] inputs = new bool[buffer.ReadInt32()];

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = buffer.ReadBoolean();
            }

            GameManager.playerList[connectionID].GetComponent<Player>().SetInput(inputs);

            buffer.Dispose();

        }

        
    }
}
