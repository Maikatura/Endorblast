using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib
{
    public class SvCharacter
    {
        public string Name;
        public int currentLobbyId;
        public int WorldID;
        public NetConnection connection;


        public StaticCharacter ToStaticCharacter()
        {
            var lc = new StaticCharacter();

            lc.connection = this.connection;
            lc.Name = this.Name;
            lc.WorldID = this.WorldID;

            return lc;
        }
    }
}
