using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using System;

namespace GamerEngineNet_Client
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {

        Scene.SceneResolutionPolicy policy;
        public static NetworkManager network;
        public GameManager manager;

        public Game1() : base()
        {
            IsFixedTimeStep = true;
            PauseOnFocusLost = false;
            DebugRenderEnabled = true;
            policy = Scene.SceneResolutionPolicy.NoBorderPixelPerfect;
            Scene.SetDefaultDesignResolution(1280, 720, policy);

            manager = new GameManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            network = new NetworkManager();

            //NetworkSend.SendHello("Hello world(server)!");

            


            base.Initialize();


            GameManager.activeScene = Scene.CreateWithDefaultRenderer(Color.CornflowerBlue);
            Core.Scene = GameManager.activeScene;
            SceneManager.Init();
            //LoginUI.InitJoin();




            NetworkConfig.InitNetwork();
            NetworkConfig.ConnectToServer();


        }

        protected override void EndRun()
        {
            NetworkConfig.DisconnectFromServer();
        }
        

    }
}
