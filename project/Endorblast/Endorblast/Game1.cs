using Endorblast.Lib;
using Nez;
using System;
using Endorblast.Lib.Discord;

namespace Endorblast
{
    public class Game1 : Core
    {

        public static NetworkManager network;
        private GameManager manager;

        public Game1() : base()
        {
            IsFixedTimeStep = true;
            PauseOnFocusLost = false;
            DebugRenderEnabled = false;
            
           

            manager = new GameManager();
            Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            
        }


        protected override void Initialize()
        {
            // Init Window stuff
            base.Initialize();
            Screen.SetSize(1280, 720);
            
            // Init Important Stuff
            DiscordRpc.NewInstance();
            NetworkManager.Instance.Start();
            Endorblast.Lib.ContentLoader.Init(Core.Content);
            DiscordRpc.Instance.Init();
            
            // Load Game State
            StateManager.Instance.SetGameState(CurrentGameState.SplashScreen);
        }


        protected override void EndRun()
        {
            //NetworkManager.Instance.ShutdownConnection();
        }

    }
}
