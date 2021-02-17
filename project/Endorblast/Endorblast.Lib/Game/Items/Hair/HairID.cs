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
            hairID.Add(1, new BaldHair(  0, "Bald"));
            hairID.Add(2, new HairNormal(1, "Pink Horns"));


            return true;
        }


        public static string GetHairName(int id)
        {
            return hairID[id].hairName;

        }
    }
}
