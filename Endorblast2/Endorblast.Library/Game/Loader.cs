using System;
using System.Data;
using System.IO;
using Endorblast.Lib.Game.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;

namespace Endorblast.Lib.Game
{
    public class Loader
    {




        public static SpriteTexture LoadTexture(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }
            
            

            Texture2D sprite = Texture2D.FromFile(Globals.gd, path);

            return new SpriteTexture(sprite);
        }


        // public static SpriteAnimation LoadSpriteAnimation(int width, int height, int fps, string path)
        // {
        //     //var animation = new SpriteAnimation(path, width, height, fps);
        //     //return animation;
        // }


    }
}