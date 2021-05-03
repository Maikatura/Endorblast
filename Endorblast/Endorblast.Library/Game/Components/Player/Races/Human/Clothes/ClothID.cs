using Nez;
using Nez.Textures;
using Nez.Verlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Library
{
    class ClothID
    {
        public static Dictionary<int, ClothObject> clothes = new Dictionary<int, ClothObject>();

        

        public static bool Init()
        {
            clothes.Add(1, new NakedOutfit(1));
            clothes.Add(2, new MaidOutfit(2));

            return true;

        }

        
        
        
    }
}
