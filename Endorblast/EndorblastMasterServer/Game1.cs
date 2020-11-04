using Endorblast.Lib;
using EndorblastServer.Server.Game.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using System;


namespace EndorblastServer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {
        ServerManager network;

        public Game1()
        {
            PauseOnFocusLost = false;
            DebugRenderEnabled = true;
            IsFixedTimeStep = true;
            ClientSettings.isClient = false;
            
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            // TODO: Add your initialization logic here
            ServerManager.NewInstance();
            MapManager.NewInstance();
            base.Initialize();

            Endorblast.Lib.ContentLoader.Init(Core.Content);
            Core.Scene = Scene.CreateWithDefaultRenderer(Color.CornflowerBlue);

            MapManager.Instance.GenerateMap(1, MapType.Town);

        }

        
        
    }
}
