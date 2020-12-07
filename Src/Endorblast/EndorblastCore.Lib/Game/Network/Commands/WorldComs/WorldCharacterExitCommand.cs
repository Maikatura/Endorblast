using EndorblastCore.Lib.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib.Game.Network.Commands
{
    class WorldCharacterExitCommand : NetCommand
    {

        public void Read(NetIncomingMessage inc)
        {


            string name = inc.ReadString();

            Console.WriteLine(name + "1231231231jsdlfjlskjdhf");

            CharacterManager.Instance.RemovePlayer(name);
        }

        public void Send()
        {
            
        }


    }
}
