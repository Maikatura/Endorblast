using System;
using System.Collections.Generic;
using Endorblast.Library.Enums;
using Nez;
using Endorblast.Library.Network;
using Endorblast.Library.Scenes;
using Endorblast.LoginServer.Data;
using CharacterSelectionData = Endorblast.Lib.Game.Data.CharacterSelectionData;

namespace Endorblast.Library
{

    

    public class SceneManager
    {
        public static SceneManager Instance { get; } = new SceneManager();

        private SceneState gameState;
        public Scene activeGameScene;

        public Scene nextGameScene;

        public SceneState GetGameState()
        {
            return gameState;
        }
        

        public Scene LoadCharacters(List<CharacterSelectionData> charaList)
        {
            return Core.Scene = new CharaSelectScene(charaList);
        }

        public Scene LoadServers(List<ServerInfo> serverList)
        {
            return Core.Scene = new ServerScene(serverList);
        }


        public Scene DemoScene()
        {
            return Core.Scene = new DemoScene();
        }
        
        public Scene LoginScene()
        {
            return Core.Scene = new LoginScene();
        }

        public Scene GameState(MapType maptype, int charaId)
        {
            Core.Scene = new TownScene(charaId);
            
            return Core.Scene;
            
        }

        public Scene SplashscreenScene()
        {
            return Core.Scene = new SplashscreenScene();
        }

        

        

        

        private void SceneTransist(Scene scene)
        {
            Core.StartSceneTransition(new WindTransition(() => scene));
        }

    }
}
