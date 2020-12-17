using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;

namespace Endorblast.Lib
{
    class HairID
    {
        public static Dictionary<int, HairObject> hairID = new Dictionary<int, HairObject>();


        public static bool Init()
        {
            hairID.Add(1, new HairNormal(1));


            return true;
        }
    }
}
