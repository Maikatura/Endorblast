using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Textures;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class ContentLoader
    {
        static string startDir = "Content";
        public static bool allLoaded = false;
        public static async void Init()
        {


            PlayerContent.Init();
            InventoryContent.Init();
            TiledMapsContent.Init();
            await ClothID.Init();
            await HairID.Init();

            allLoaded = true;
        }


        public static Sprite LoadSprite(string path)
        {
            Sprite sprite = new Sprite(Core.Content.LoadTexture(startDir + path));
            return sprite;
        }

        public static TmxMap LoadTiledMap(string path)
        {
            TmxMap map = Core.Content.LoadTiledMap(startDir + path);
            return map;
        }
    }


    class PlayerContent
    {

        public static Entity dummyPlayer;

        public static Sprite playerIdle;
        public static Sprite playerWalking;
        public static Sprite nothing;
        public static Sprite playerBasicAttack;


        public static void Init()
        {
            dummyPlayer = new Entity("DummyPlayer");


            nothing = ContentLoader.LoadSprite("/Player/nothing.png");
            playerIdle = ContentLoader.LoadSprite("/Player/Base/Chara_Idle.png");
            playerWalking = ContentLoader.LoadSprite("/Player/Base/Chara_Running.png");
            playerBasicAttack = ContentLoader.LoadSprite("/Player/Base/Chara_BasicAttack.png");
        }
    }

    class InventoryContent
    {
        public static Sprite slotIcon;


        public static void Init()
        {
            slotIcon = ContentLoader.LoadSprite("/UI/Login/UI_Login2.png");
        }
    }


    class TiledMapsContent
    {
        public static TmxMap mainMenuTiledmap;
        public static TmxMap gameTiledmap;

        public static void Init()
        {
            mainMenuTiledmap = ContentLoader.LoadTiledMap("/Tilesets/MainMenu/MainMenu.tmx");
            gameTiledmap = ContentLoader.LoadTiledMap("/Tilesets/GameArea/GameStart.tmx");
        }
    }

    class EffectContent
    {
        public static Effect blur;
        public static SpriteEffects test;

        public static void Init()
        {
            blur = Core.Content.LoadEffect("Contnet/Effects/blur.fx");
            
        }
    }


}
