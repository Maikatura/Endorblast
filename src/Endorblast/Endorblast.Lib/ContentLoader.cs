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

namespace Endorblast.Lib
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
            InventoryContent.Init();
            TiledMapsContent.Init();
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
        private static string path = "/Sprites/Player/Races";
        public static Sprite maleIdle;
        public static Sprite maleWalking;
        public static Sprite maleBasicAttack;
        
        
        // Female
        public static Sprite femaleIdle;
        public static Sprite femaleWalking;
        public static Sprite femaleBasicAttack;
        
        
        // Werewolf
        public static Sprite werewolfIdle;
        public static Sprite werewolfWalking;
        public static Sprite werewolfBasicAttack;
     
        public static void Init()
        {
            dummyPlayer = new Entity("DummyPlayer");

            nothing = ContentLoader.LoadSprite("/Sprites/Player/Clothes/nothing/nothing.png");
            
            // Male
            maleIdle = ContentLoader.LoadSprite(path + "/Human/Male/TestingSprite.png");
            maleWalking = ContentLoader.LoadSprite(path + "/Human/Male/Running.png");
            maleBasicAttack = ContentLoader.LoadSprite(path + "/Human/Male/BasicAttack.png");
            
            // Female
            femaleIdle = ContentLoader.LoadSprite(path + "/Human/Female/Idle.png");
            femaleWalking = ContentLoader.LoadSprite(path + "/Human/Female/Running.png");
            femaleBasicAttack = ContentLoader.LoadSprite(path + "/Human/Female/BasicAttack.png");
        }
    }

    public class InventoryContent
    {
        public static Sprite slotIcon;


        public static void Init()
        {
            slotIcon = ContentLoader.LoadSprite("/Sprites/UI/Login/UI_Login2.png");
        }
    }


    public class TiledMapsContent
    {
        public static TmxMap mainMenuTiledmap;
        public static TmxMap gameTiledmap;

        public static void Init()
        {
            mainMenuTiledmap = ContentLoader.LoadTiledMap("/Sprites/Tilesets/MainMenu/MainMenu.tmx");
            gameTiledmap = ContentLoader.LoadTiledMap("/Sprites/Tilesets/GameArea/GameStart.tmx");
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
