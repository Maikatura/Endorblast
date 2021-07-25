using System;
using System.Runtime.InteropServices;
using Endorblast.Backend.Tokens;
using Endorblast.DBase;
using Endorblast.GameServer.Server;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class ServerEnterWorldCmd : NetCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            int charaId = inc.ReadInt32();
            string token = inc.ReadString();
            string address = inc.SenderEndPoint.Address.ToString();
            
            var result = new VerifyToken().Validate(address, token);

            if (result.Item2 == false)
                return;

            string accountName = result.Item1;
            var characterExist = new AccountCharacterExistCmd().GetCharacter(accountName, charaId);

            if (!characterExist)
            {
                // TODO : Send Error message
                return;
            }

            Console.WriteLine("LOL");
            var sender = inc.SenderConnection;
            
            var map = MapManager.Instance.AddPlayer(sender, charaId);
            Console.WriteLine("World ID: "+map.worldId);
            Send(sender, charaId, map.worldId, map.mapType);
        }


        public void Send(NetConnection sender,int charaId, int worldID, MapType mapType)
        {
            Console.WriteLine("World ID: "+worldID);
            var list = MapManager.Instance.GetConnections(worldID);
            var outmsg = netmana.GAMEMSG();
            outmsg.Write((byte)GamePacket.MapData);
            outmsg.Write((byte)MapPacket.WorldEnter);
            
            
            outmsg.Write(worldID);
            outmsg.Write((byte)mapType);
            outmsg.Write(charaId);
            
            
            server.SendMessage(outmsg, list, NetDeliveryMethod.ReliableOrdered, 0);
        }
    }
}