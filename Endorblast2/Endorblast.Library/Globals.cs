using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib
{
    public class Globals
    {

        public static SpriteFont font;
        public static SpriteBatch sb;
        public static GraphicsDevice gd;
        public static ContentManager cm;

        public Globals(SpriteBatch spriteb, GraphicsDevice grapd, ContentManager contentm)
        {
            sb = spriteb;
            gd = grapd;
            cm = contentm;
        }

    }
}