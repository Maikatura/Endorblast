using System;
using Endorblast.Lib.Game.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;

namespace Endorblast.Lib.Game.Renderer
{
    public class SpriteAnimation
    {

        private string Path;
        private int framesPerSecond = 1;        // FPS : If you don't have a lot of frames don't set it to a high value!
        private float timeToNextFrame;
        private float elapsedTime;
        

        private int currentFrameX = 0;
        private int currentFrameY = 0;

        private SpriteTexture sprite;
        private Rectangle spriteRectangle;

        private int Width, Height;
        
        

        public SpriteAnimation()
        {
            
        
        }
    

        public SpriteAnimation(string path, int width, int height, int fps) : base()
        {
            
        
        }
        
        public static SpriteAnimation MakeAnimation(string path, int width, int height, int fps)
        {
            SpriteAnimation animation = new SpriteAnimation(path, width, height, fps);
            return animation;
        }
        
        public Rectangle NextFrame()
        {
            Rectangle rectangle = new Rectangle();

            MoreXYFrames();

            rectangle.Width = Width;
            rectangle.Height = Height;
            
            rectangle.X = Width * currentFrameX;
            rectangle.Y = Height * currentFrameY;

            spriteRectangle = rectangle;
            return rectangle;
        }


        // Check if there are more frames on X and Y and resets if there are none
        private void MoreXYFrames()
        {
            if (Width * currentFrameX >= sprite.Width - Width)
            {
                currentFrameX = 0;
                
                if (Height * currentFrameY >= sprite.Height - Height)
                {
                    currentFrameY = 0;
                }
                else
                {
                    currentFrameY++;
                }
            }
            else
            {
                currentFrameX++;
            }
        }

        
        public void Update(float gameTime)
        {
            // Like nez but also not....
            float fps = 1 / (float)framesPerSecond;
            float duration = fps;

            elapsedTime += gameTime;
            var time = Math.Abs(elapsedTime);
            
            if (time > duration)
            {
                elapsedTime = 0;
                NextFrame();
            }
        }
        
        
        public void Draw(SpriteBatch sb, float gameTime, Vector2 pos, Vector2 scale, float rotatino)
        {
            
            var position = pos;
            var centerPos = new Vector2(position.X - (Width / 2) * scale.X, position.Y - (Height / 2));
            
            
            //sb.Draw(sprite.Texture, ), spriteRectangle, Color.White);
            
            sb.Draw(sprite.Texture, centerPos, spriteRectangle, Color.White,
                0, new Vector2(0,0), scale, SpriteEffects.None, 0);
        }
    }
}