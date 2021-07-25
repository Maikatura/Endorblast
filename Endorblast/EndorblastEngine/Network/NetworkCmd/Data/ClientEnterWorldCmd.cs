using System;
using Endorblast.Lib.Game.Data;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;
using Nez;

namespace EndorblastEngine.Network.NetworkCmd.Game
{
    public class ClientEnterWorldCmd : NetCommand
    {
        
        
        public void Send(int characterId)
        {
            var token = GameManager.GetLoginToken;

            var outmsg = netmana.CreateGameMessage();
            outmsg.Write((byte)GamePacket.MapData);
            outmsg.Write((byte)MapPacket.WorldEnter);

            GameManager.SetCharacterID = characterId;
            
            outmsg.Write(characterId);
            outmsg.Write(token);

            client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

        public void Read(NetIncomingMessage inc)
        {
            int worldId = inc.ReadInt32();
            MapType mapType = (MapType) inc.ReadByte();
            int charaId = inc.ReadInt32();

            if (charaId == GameManager.GetCharacterID)
            {
                SceneManager.Instance.GameState(mapType, charaId);
            }
            else
            {
                GameManager.Instance.AddPlayer("Zyro");
            }

            // CharacterSelectionData chara = new CharacterSelectionData();
            // inc.ReadAllFields(chara);
            
            
            
        }
        
        
    }
}