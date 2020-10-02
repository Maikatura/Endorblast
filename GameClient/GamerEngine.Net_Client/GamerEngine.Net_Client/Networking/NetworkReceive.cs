using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaymakNetwork.Network.Client;
using Microsoft.Xna.Framework;
using Nez;


namespace GamerEngineNet_Client
{

    enum ServerPackets
    {
        SWelcomeMsg = 1,
        SSpawnPlayer,
        SRemovePlayer,
        SPlayerPos,
    }


    internal static class NetworkReceive
    {

        internal static void PacketRouter()
        {
            NetworkConfig.socket.PacketId[(int)ServerPackets.SWelcomeMsg] = new Client.DataArgs(Packet_Message);
            NetworkConfig.socket.PacketId[(int)ServerPackets.SSpawnPlayer] = new Client.DataArgs(Packet_SpawnPlayer);
            NetworkConfig.socket.PacketId[(int)ServerPackets.SRemovePlayer] = new Client.DataArgs(Packet_RemovePlayer);
            NetworkConfig.socket.PacketId[(int)ServerPackets.SPlayerPos] = new Client.DataArgs(Packet_GetPlayerPos);

        }

        private static void Packet_GetPlayerPos(ref byte[] data)
        {

            ByteBuffer buffer = new ByteBuffer(data);

            int connectionID = buffer.ReadInt32();

            float x = buffer.ReadSingle();
            float y = buffer.ReadSingle();

            bool isRunning = buffer.ReadBoolean();
            bool isIdle = buffer.ReadBoolean();


            GameManager.instance.playerList[connectionID].GetComponent<PlayerClass>().UpdatePlayerPos(new Vector2(x, y), isRunning, isIdle);

            buffer.Dispose();
        }

        private static void Packet_Message(ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);

            int connectionID = buffer.ReadInt32();
            string msg = buffer.ReadString();

            GameManager.instance.connectionID = connectionID;
            Console.WriteLine(msg);

            buffer.Dispose();

            NetworkSend.SendHello("Spawn me In");
        }

        private static void Packet_SpawnPlayer(ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);
            int connectionID = buffer.ReadInt32();
            bool inGame = buffer.ReadBoolean();

            if (connectionID == GameManager.instance.connectionID)
            {
                GameManager.instance.AddEntity(connectionID, true);
            }
            else
            {
                GameManager.instance.AddEntity(connectionID, false);
            }

            buffer.Dispose();
        }

        private static void Packet_RemovePlayer(ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);
            int connectionID = buffer.ReadInt32();

            GameManager.instance.RemoveEntity(connectionID);

            buffer.Dispose();
        }

        
    }
}

