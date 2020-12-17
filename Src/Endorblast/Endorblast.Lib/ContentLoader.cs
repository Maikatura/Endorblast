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

        public static Sprite playerIdle;
        public static Sprite playerWalking;
        public static Sprite nothing;
        public static Sprite playerBasicAttack;

        


        public static void Init()
        {
            dummyPlayer = new Entity("DummyPlayer");

            
            nothing = ContentLoader.LoadSprite("/Sprites/Player/Clothes/nothing/nothing.png");
            playerIdle = ContentLoader.LoadSprite("/Sprites/Player/Base/Chara_Idle.png");
            playerWalking = ContentLoader.LoadSprite("/Sprites/Player/Base/Chara_Running.png");
            playerBasicAttack = ContentLoader.LoadSprite("/Sprites/Player/Base/Chara_BasicAttack.png");
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
