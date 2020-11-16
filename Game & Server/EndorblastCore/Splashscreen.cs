using EndorblastCore.Lib;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore
{
    class Splashscreen
    {

        static Splashscreen Instance;


        public static void SplashscreenStart()
        {
            Core.Scene = Scene.CreateWithDefaultRenderer(Color.Black);

            Sprite texture = ContentLoader.LoadSprite("/Logos/Splashscreen1.png");

            Entity splashScreen = new Entity("Splashscreen");
            splashScreen.AddComponent(new SpriteRenderer(texture));

            Core.Scene.AddEntity(splashScreen);

            float time = 0;


            



        }

    }
}
