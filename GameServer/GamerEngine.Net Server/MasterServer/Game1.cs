using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace MasterServer
{

    public class Game1 : Core
    {
        

        public Game1()
        {
            PauseOnFocusLost = false;
            DebugRenderEnabled = true;
            IsFixedTimeStep = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            MasterScene.Init("Content/MainMenu.tmx");

            MainServer server = new MainServer();
            server.Init(ServerSettings.serverPort, ServerSettings.maxPlayers);
            server.Start();

        }

        
    }
}
