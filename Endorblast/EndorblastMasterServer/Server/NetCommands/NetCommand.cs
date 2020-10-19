using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    public enum WorldPacket
    {
        Data,
        CharacterEnder,
    }

    public enum CharacterPacket
    {
        SkillCast,
        Data,
        List
    }

    public class NetCommand
    {

        
    }
}
