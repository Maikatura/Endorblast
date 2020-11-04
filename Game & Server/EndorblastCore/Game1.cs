using EndorblastCore.Lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace EndorblastCore
{
    public class Game1 : Core
    {

        Scene.SceneResolutionPolicy policy;
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


            //NetworkSend.SendHello("Hello world(server)!");
            base.Initialize();

            Screen.SetSize(1280, 720);
            Scene.SetDefaultDesignResolution(1280, 720, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            DefaultSamplerState = SamplerState.PointClamp;

            NetworkManager.NewInstance();


            DiscordRpc.Instance.Init();
            EndorblastCore.Lib.ContentLoader.Init(Core.Content);
            GameState.SetGameState(CurrentGameState.MainMenu);

            //LoginUI.InitJoin(Core.Scene);
            //InventoryUI.InitInventory();
        }

        protected override void EndRun()
        {
            NetworkManager.Instance.client.Disconnect("Bye");
            NetworkManager.Instance.client.Shutdown("Bye");
        }

    }
}
