using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MasterServer
{

    enum ServerPackets
    {
        SWelcomeMsg = 1,
        SSpawnPlayer,
        SRemovePlayer,
        SPlayerPos,
    }

    internal static class NetworkSend
    {
        public static void WelcomeMessage(int connectionID, string msg)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SWelcomeMsg);
            buffer.WriteInt32(connectionID);

            buffer.WriteString(msg);

            NetworkConfig.Socket.SendDataTo(connectionID, buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        private static ByteBuffer PlayerData(int connectionID, Player player)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SSpawnPlayer);

            buffer.WriteInt32(connectionID);
            buffer.WriteBoolean(player.inGame);

            return buffer;
        }

        public static void InstantiateNetworkPlayer(int connectionID, Player player)
        {
            for (int i = 1; i <= GameManager.playerList.Count; i++)
            {
                if (GameManager.playerList.ContainsKey(i))
                {
                    if (GameManager.playerList[i] != null)
                    {
                        if (GameManager.playerList[i].GetComponent<Player>().inGame)
                        {
                            if (i != connectionID)
                            {
                                NetworkConfig.Socket.SendDataTo(connectionID, PlayerData(i, GameManager.playerList[i].GetComponent<Player>()).Data, PlayerData(i, GameManager.playerList[i].GetComponent<Player>()).Head);
                            }
                        }
                    }
                }
            }



            for (int i = 1; i <= GameManager.playerList.Count; i++)
            {
                if (GameManager.playerList.ContainsKey(i))
                {
                    if (GameManager.playerList[i] != null)
                    {
                        if (GameManager.playerList[i].GetComponent<Player>().inGame)
                        {
                            NetworkConfig.Socket.SendDataTo(i, PlayerData(connectionID, player).Data, PlayerData(connectionID, player).Head);
                        }
                    }
                }
            }

            //NetworkConfig.Socket.SendDataToAll(PlayerData(connectionID, player).Data, PlayerData(connectionID, player).Head);

        }


        public static void SendPlayerPos(int connectionID, Vector2 position, bool isWalking, bool isIdle)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SPlayerPos);

            buffer.WriteInt32(connectionID);
            buffer.WriteSingle(position.X);
            buffer.WriteSingle(position.Y);

            buffer.WriteBoolean(isWalking);
            buffer.WriteBoolean(isIdle);

            NetworkConfig.Socket.SendDataToAll(buffer.Data, buffer.Head);
            buffer.Dispose();



        }

        public static void SendRemovePlayer(int connectionID)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SRemovePlayer);
            buffer.WriteInt32(connectionID);

            NetworkConfig.Socket.SendDataToAll(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

    }
}
