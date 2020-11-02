using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class NakedOutfit : ClothObject
    {

        public NakedOutfit()
        {
            hatIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);
            clothIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);
            shoeIdle = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);

            hatRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);
            clothRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);
            shoeRunning = new SpriteAnimation(LoadSpriteAtlas("/Player/nothing.png"), 10);

            Console.WriteLine("Loaded ID:1");
        }
    }
}
