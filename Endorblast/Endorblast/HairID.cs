using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class HairID
    {
        public static Dictionary<int, HairObject> hairID = new Dictionary<int, HairObject>();


        public static async Task<bool> Init()
        {
            hairID.Add(1, new HairNormal());


            return true;
        }
    }
}
