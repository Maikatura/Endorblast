using EndorblastServer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using System.Diagnostics;

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
            ServerManager.NewInstance();
            base.Initialize();
        }

        
        
    }
}
