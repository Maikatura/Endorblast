using System;
using System.Collections.Generic;
using System.Linq;
using Endorblast.Lib.Game.Data;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Endorblast.Library.Network;
using Endorblast.Library.Scenes;
using Lidgren.Network;
using Nez;

namespace EndorblastEngine.Network.NetworkCmd
{
    public class ReceiveCharactersCmd : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {

            var count = inc.ReadInt32();
            var list = new List<CharacterSelectionData>();

            for (int i = 0; i < count; i++)
            {
                var chara = new CharacterSelectionData();
                inc.ReadAllFields(chara);
                list.Add(chara);

                
                Console.WriteLine(chara.ToString());
                
            }
            
            SceneManager.Instance.LoadCharacters(list);
        }

        public void Send(string token)
        {
            var outmsg = netmana.CreateGameMessage();
            
            outmsg.Write((byte)GamePacket.Logic);
            outmsg.Write((byte)GameLogicPacket.RequestCharacter);
            outmsg.Write(token);

            client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}