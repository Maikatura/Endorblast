using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class HairObject
    {

        public SpriteAnimation frontHairIdle;
        public SpriteAnimation frontHairRunning;

        public SpriteAnimation backHairIdle;
        public SpriteAnimation backHairRunning;


        protected Sprite[] LoadSpriteAtlas(string path)
        {
            Sprite[] spriteArray = Sprite.SpritesFromAtlas(ContentLoader.LoadSprite(path), 64, 64).ToArray();
            return spriteArray;
        }
    }
}
