using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class MaidOutfit : ClothObject
    {

        public MaidOutfit()
        {
            hatIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Headband.png"), 10);
            clothIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Body.png"), 10);
            shoeIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Stockings.png"), 10);

            hatRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Headband_Running.png"), 10);
            clothRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Body_Running.png"), 10);
            shoeRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/Clothes/Maid/Maid_Stockings_Running.png"), 10);
            Console.WriteLine("Loaded ID:2");
        }

    }
}
