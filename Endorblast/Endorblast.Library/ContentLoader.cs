using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Systems;
using Nez.Textures;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Library
{
    public class ContentLoader
    {
        static string startDir = "Content";
        public static bool allLoaded = false;
        static NezContentManager conManager;

        public static void Init(NezContentManager manager)
        {
            conManager = manager;

            PlayerContent.Init();
            ClothID.Init();
            HairID.Init();

            allLoaded = true;
        }


        public static Sprite LoadSprite(string path)
        {
            Sprite sprite = new Sprite(conManager.LoadTexture(startDir + path));
            return sprite;
        }

        public static Sprite[] LoadSprites(string path, int width, int height)
        {

            Sprite[] sprite = Sprite.SpritesFromAtlas(LoadSprite(path), width, height).ToArray();
            return sprite;
        }
        
        

        public static TmxMap LoadTiledMap(string path)
        {
            TmxMap map = conManager.LoadTiledMap(startDir + path);
            return map;
        }

        public static Effect LoadEffect(string path)
        {
            Effect effect = conManager.LoadEffect(startDir + path);
            return effect;
        }
    }


    public class PlayerContent
    {

        public static Entity dummyPlayer;

        public static Sprite nothing;


        /// <summary>
        /// Classes Sprite
        /// </summary>

        // Male


        public static void Init()
        {
            dummyPlayer = new Entity("DummyPlayer");

            nothing = ContentLoader.LoadSprite("/Textures/Spritesheets/Player/Clothes/nothing/nothing.png");


        }

        public class InventoryContent
        {
            public static Sprite slotIcon;


            public static void Init()
            {
                slotIcon = ContentLoader.LoadSprite("/Textures/Misc/UI/Login/UI_Login2.png");
            }
        }


        public class TiledMapsContent
        {
            

            public static void Init()
            {
                
            }
        }

        public class EffectContent
        {
            public static Effect blur;
            public static SpriteEffects test;

            public static void Init()
            {


            }
        }


    }
}
