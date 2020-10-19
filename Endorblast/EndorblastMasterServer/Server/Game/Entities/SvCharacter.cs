using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    public class SvCharacter
    {
        public string Name;
        public int currentLobbyId;
        public int WorldID;
        public NetConnection connection;


        public LibCharacter ToLibCharacter()
        {
            var lc = new LibCharacter();

            lc.Connection = this.connection;
            lc.Name = this.Name;
            lc.WorldID = this.WorldID;

            return lc;
        }
    }
}
