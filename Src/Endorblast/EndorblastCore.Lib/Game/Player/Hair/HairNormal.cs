
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
        public HairNormal()
        {
            frontHairIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/Hair/Chara_Idle_FrontHair_V1.png"), 10);
            frontHairRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/Hair/Chara_Running_FrontHair_V1.png"), 10);
           
            backHairIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/Hair/Chara_Idle_BackHair_V1.png"), 10);
            backHairRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/Hair/Chara_Running_BackHair_V1.png"), 10);
        }
    }
}
