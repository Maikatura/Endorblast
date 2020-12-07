using EndorblastCore.Server.NetCommands;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Server
{
    public class PlayerStats : Component, IUpdatable
    {


        public void Update()
        {
            //new CharacterDataCommand().Send(EndorblastCore.Lib.Enums.CharacterDataType.Position, this.GetComponent<EndorblastCore.Lib.BasePlayer>());
        }

    }
}
