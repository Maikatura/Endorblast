using Nez;
using Nez.Sprites;
using Nez.Textures;
using Endorblast.Lib;

namespace Endorblast
{
    class ClothObject
    {
        public SpriteAnimation hatIdle;
        public SpriteAnimation clothIdle;
        public SpriteAnimation shoeIdle;

        public SpriteAnimation hatRunning;
        public SpriteAnimation clothRunning;
        public SpriteAnimation shoeRunning;


        protected Sprite[] LoadSpriteAtlas(string path)
        {
            Sprite[] spriteArray = Sprite.SpritesFromAtlas(ContentLoader.LoadSprite(path), 64, 64).ToArray();
            return spriteArray;
        }


        


    }
}
