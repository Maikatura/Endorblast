
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;

namespace EndorblastCore.Lib
{
    class HairNormal : HairObject
    {
        public HairNormal(int id)
        {
            frontHairIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/Chara_Idle_FrontHair_V1.png"), 10);
            frontHairRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/Chara_Running_FrontHair_V1.png"), 10);
           
            backHairIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/Chara_Idle_BackHair_V1.png"), 10);
            backHairRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/Chara_Running_BackHair_V1.png"), 10);
            
            Id = id;
            Console.WriteLine($"Loaded ID:{id}");
        }
    }
}
