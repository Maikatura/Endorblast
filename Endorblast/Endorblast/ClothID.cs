using Nez;
using Nez.Textures;
using Nez.Verlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class ClothID
    {
        public static Dictionary<int, ClothObject> clothes = new Dictionary<int, ClothObject>();


        public static async Task<bool> Init()
        {
            clothes.Add(1, new NakedOutfit());
            clothes.Add(2, new MaidOutfit());

            return true;

        }


    }
}
