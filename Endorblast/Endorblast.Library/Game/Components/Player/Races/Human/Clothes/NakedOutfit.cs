using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Library
{
    class NakedOutfit : ClothObject
    {

        
        
        public NakedOutfit(int id)
        {
            hatIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            clothIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            shoeIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);

            hatRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            clothRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            shoeRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);

            Id = id;
            Console.WriteLine($"Loaded ID:{id}");
        }
    }
}
