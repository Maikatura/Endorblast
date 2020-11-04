using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;

namespace EndorblastCore.Lib
{
    class HairID
    {
        public static Dictionary<int, HairObject> hairID = new Dictionary<int, HairObject>();


        public static bool Init()
        {
            hairID.Add(1, new HairNormal());


            return true;
        }
    }
}
