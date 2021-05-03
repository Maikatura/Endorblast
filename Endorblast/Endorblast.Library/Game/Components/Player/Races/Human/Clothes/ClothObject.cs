using Endorblast.Library.Game;
using Endorblast.Library.Scenes;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library
{
    class ClothObject
    {
        public int Id;
        public string path = $"{ContentPath.Instance.clothPath}";
        
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
