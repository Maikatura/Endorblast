using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Library
{
    class MaidOutfit : ClothObject
    {
        
        public MaidOutfit(int id)
        {
            hatIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Headband.png"), 10);
            clothIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Body.png"), 10);
            shoeIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Stockings.png"), 10);

            hatRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Headband_Running.png"), 10);
            clothRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Body_Running.png"), 10);
            shoeRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/Maid/Maid_Stockings_Running.png"), 10);
            
            Id = id;
            Console.WriteLine($"Loaded ID:{id}");
        }

    }
}
