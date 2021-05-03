using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Game;

namespace Endorblast.Library
{
    class HairObject
    {
        public int Id;
        public string path = $"{ContentPath.Instance.hairPath}";

        public string hairName;
        
        public SpriteAnimation frontHairIdle;
        public SpriteAnimation frontHairRunning;

        public SpriteAnimation backHairIdle;
        public SpriteAnimation backHairRunning;


        public HairObject(int id, string name)
        {
            
        }

        protected Sprite[] LoadSpriteAtlas(string path)
        {
            Sprite[] spriteArray = Sprite.SpritesFromAtlas(ContentLoader.LoadSprite(path), 64, 64).ToArray();
            return spriteArray;
        }
    }
}
