using System;
using Nez;
using Endorblast.Library.Discord;
using Endorblast.Library.Entities.Player;
using Endorblast.Library.Enums;
using EndorblastEngine.Network;
using Microsoft.Xna.Framework;
using Nez.UI;

namespace Endorblast.Library
{
    public class GameManager
    {
        private NetworkManager network;

        public static GameManager Instance;

        private static string loginToken = "";
        private static string username = "";
        private static int characterId = -1;

        public static string GetLoginToken
        {
            get
            {
                return loginToken;
            }
        }
        
        public static string SetLoginToken
        {
            private get
            {
                return "";
            }
            set
            {
                loginToken = value;
            }
        }
        
        public static int GetCharacterID
        {
            get
            {
                return characterId;
            }
        }
        
        public static int SetCharacterID
        {
            private get
            {
                return -1;
            }
            set
            {
                characterId = value;
            }
        }
        public static string GetUsername
        {
            get
            {
                return username;
            }
        }
        public static string SetUsername
        {
            private get
            {
                return "";
            }
            set
            {
                username = value;
            }
        }

        private Skin skin;
        

        public void Init()
        {
            Instance = this;
            
            Screen.SynchronizeWithVerticalRetrace = false;
            Screen.SetSize(1280, 720);

            network = new NetworkManager();

            ContentLoader.Init(Core.Content);
            
            DiscordRpc.NewInstance();
            DiscordRpc.Instance.Init();

            SceneState type = SceneState.LoginMenu;
            
            switch (type)
            {
                case SceneState.DemoScene:
                    SceneManager.Instance.DemoScene();
                    break;
                case SceneState.SplashScreen:
                    SceneManager.Instance.SplashscreenScene();
                    break;
                case SceneState.LoginMenu:
                    SceneManager.Instance.LoginScene();
                    break;
                case SceneState.RegisterMenu:
                    Console.WriteLine($"Cant change to {type.ToString()} : Just run Login Scene.");
                    SceneManager.Instance.LoginScene();
                    break;
                
                default:
                    Console.WriteLine($"Cant change to {type.ToString()} : Login to do this.");
                    SceneManager.Instance.LoginScene(); 
                    break;
            }

        }


        public void LoadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void AddPlayer(string name, bool isOwn = false)
        {
            if (isOwn)
            {
                Console.WriteLine("Added local player");
                var entity = new MainPlayer(name);
                Core.Scene.AddEntity(entity);
            }
            else
            {
                Console.WriteLine("Added Online player");
                var entity = new BasePlayer(name);
                Core.Scene.AddEntity(entity);
            }
        }
    }
    
}