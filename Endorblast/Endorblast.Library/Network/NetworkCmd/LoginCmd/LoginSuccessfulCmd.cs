using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Endorblast.Lib.Game.Data;
using Lidgren.Network;

namespace Endorblast.Library.Network
{
    public class LoginSuccessfulCmd
    {
        public void Read(NetIncomingMessage inc)
        {

            string username = inc.ReadString();
            
            
            var chars = new List<CharacterSelectionData>();
            
            int count = inc.ReadInt32();

            Console.WriteLine(count);

            for (int i = 2; i < count; i++)
            {
                var thisChara = new CharacterSelectionData();
                inc.ReadAllFields(thisChara);
                chars.Add(thisChara);
            }


            Console.WriteLine("Working! :D");
            //StateManager.Instance.SetGameState(CurrentGameState.CharacterSelection, chars);
        }
    }
}