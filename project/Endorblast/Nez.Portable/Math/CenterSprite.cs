using Microsoft.Xna.Framework;
using Nez.Textures;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nez
{
    public class CenterSprite
    {

        public static Vector2 CenterOrigin(Sprite sprite)
        {
            Vector2 returnOrigion = sprite.Center;

            return returnOrigion;
        }

        public static Vector2 BottonOrigin(Sprite sprite)
        {
            Vector2 returnOrigion = new Vector2(sprite.SourceRect.Width / 2, sprite.SourceRect.Height);

            return returnOrigion;
        }


        public static Vector2 TopOrigin(Sprite sprite)
        {
            Vector2 returnOrigion = new Vector2(sprite.SourceRect.Width / 2, 0);

            return returnOrigion;
        }


        public static Sprite[] BottomOrigin(Sprite[] sprites)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].Origin = BottonOrigin(sprites[i]);
            }

            return sprites;
        }

        public static Sprite[] TopOrigin(Sprite[] sprites)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].Origin = TopOrigin(sprites[i]);
            }

            return sprites;
        }

        public static Sprite[] CenterOrigin(Sprite[] sprites)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].Origin = CenterOrigin(sprites[i]);
            }

            return sprites;
        }

    }
}
