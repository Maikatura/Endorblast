using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Lidgren.Network;

namespace Endorblast.Lib.Network
{
    public class LoginSuccessfulCmd
    {
        public void Read(NetIncomingMessage inc)
        {

            string username = inc.ReadString();
            
            
            var chars = new List<DatabaseCharacter>();
            
            int count = inc.ReadInt32();

            Console.WriteLine(count);

            for (int i = 0; i < count; i++)
            {
                var thisChara = new DatabaseCharacter();
                inc.ReadAllFields(thisChara);
                chars.Add(thisChara);
            }
            
            
            StateManager.Instance.SetGameState(CurrentGameState.CharacterSelection, chars);
        }
    }
}