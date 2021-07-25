using Endorblast.Library;
using Nez;
using System;
using Endorblast.Library.Discord;
using Endorblast.Library.Enums;
using EndorblastEngine.Network;
using Microsoft.Xna.Framework;

//using Nez.ImGuiTools;

namespace EndorblastEngine
{
    public class Game1 : Core
    {
        
        private GameManager manager;
        private TitleManager statusManager;

        //private ImGuiManager imGuiManager;
        
        public Game1() : base()
        {
            IsFixedTimeStep = true;
            PauseOnFocusLost = false;
            DebugRenderEnabled = false;
            Window.AllowUserResizing = true;
            
            
            manager = new GameManager();
            statusManager = new TitleManager(Window);
        }


        protected override void Initialize()
        {
            base.Initialize();
            manager.Init();
        }

        
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            statusManager.Update(gameTime);
        }
    }
}
