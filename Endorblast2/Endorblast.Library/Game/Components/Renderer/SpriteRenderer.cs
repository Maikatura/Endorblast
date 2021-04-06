using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Renderer
{
    public class SpriteRenderer
    {
        private SpriteTexture sprite;


        public SpriteRenderer(SpriteTexture sprite)
        {
            
            this.sprite = sprite;
        }
        
        public SpriteTexture SetSprite(SpriteTexture sprite)
        {
            this.sprite = sprite;
            return sprite;
        }


        public void Draw(SpriteBatch sb, GameTime gt)
        {
            

            
            var position = new Vector2(Globals.gd.Viewport.Width / 2, Globals.gd.Viewport.Height / 2);
            sb.Draw(sprite.Texture, position, Color.White);

            // var spriteRectangle = new Rectangle(0, 0, 64, 64);
            //
            // var scale = new Vector2(1, 1);
            // 
            //
            // Globals.sb.Draw(sprite.Texture, position, spriteRectangle, Color.White,
            //     0, new Vector2(0,0), scale, SpriteEffects.None, 0);
           

            Console.WriteLine("LOL");
            
        }


        public void Update(GameTime gameTime)
        {
            
        }
    }
}