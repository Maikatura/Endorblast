using EndorblastCore.Lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.DeferredLighting;
using System;
using static Nez.Scene;

namespace EndorblastCore
{
    public class Game1 : Core
    {

        public static NetworkManager network;
        public GameManager manager;

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
            // TODO: Add your initialization logic here
            DiscordRpc.NewInstance();
            NetworkManager.NewInstance();

            //NetworkSend.SendHello("Hello world(server)!");
            base.Initialize();

            Screen.SetSize(1280, 720);


            DefaultSamplerState = SamplerState.PointClamp;

            EndorblastCore.Lib.ContentLoader.Init(Core.Content);
            DiscordRpc.Instance.Init();
            
            GameState.Instance.SetGameState(CurrentGameState.SplashScreen);

            
        }


        protected override void EndRun()
        {
            //NetworkManager.Instance.ShutdownConnection();
        }

    }
}
