using System;
using System.Collections.Generic;
using Nez;
using Endorblast.Library.Network;
using Endorblast.Library.Scenes;
using Endorblast.LoginServer.Data;

namespace Endorblast.Library
{

    public enum CurrentGameState
    {
        DemoScene,
        SplashScreen,
        LoginMenu,           // Login screen
        ServerMenu,
        RegisterMenu,       // Where you register youself
        CharacterSelection,
        CharacterCreation,
        PlayingState,       // Player is ingame an running the full game
    }

    public class StateManager
    {
        public static StateManager Instance { get; } = new StateManager();

        private CurrentGameState gameState;
        public Scene activeGameScene;

        public Scene nextGameScene;

        public CurrentGameState GetGameState()
        {
            return gameState;
        }

        public void SetGameState(CurrentGameState wantedGameState)
        {
            gameState = wantedGameState;
            LoadGameState(gameState);
        }

        public void SetGameState(CurrentGameState wantedGameState, List<DatabaseCharacter> charaSelect = null)
        {
            gameState = wantedGameState;
            LoadGameState(gameState, charaSelect, null);
        }


        public void SetGameState(List<GameServerInfo> data)
        {
            LoadGameState(CurrentGameState.ServerMenu, null, data);
        }

        private void LoadGameState(CurrentGameState gameStateToSet, List<DatabaseCharacter> charaSelect = null, List<GameServerInfo> data = null)
        {
            if (Core.Scene == null)
            {
                var scene = new BlackScene();
                Core.Scene = scene;
            }
            
            switch (gameStateToSet)
            {
                case CurrentGameState.DemoScene:
                    var scene = new DemoScene();
                    Core.Scene = scene;
                    break;
                case CurrentGameState.SplashScreen:
                    LoadSplash();
                    break;
                case CurrentGameState.LoginMenu:
                    LoadMainMenu();
                    break;
                case CurrentGameState.RegisterMenu:
                    Console.WriteLine("Not made!");
                    break;
                case CurrentGameState.CharacterSelection:
                    LoadCharacterSelect(charaSelect);
                    break;
                case CurrentGameState.CharacterCreation:
                    LoadCreation();
                    break;
                case CurrentGameState.PlayingState:
                    LoadGameState();
                    break;
                case CurrentGameState.ServerMenu:
                    break;
                default:
                    break;
            }
        }



        private void LoadSplash()
        {
            SceneTransist(new SplashscreenScene());
            
        }
        
        private void LoadMainMenu()
        {
            SceneTransist(new LoginScene());
        }

        private void LoadCharacterSelect(List<DatabaseCharacter> charaSelect)
        {
            Core.Scene = new CharaSelectScene(charaSelect);
        }

        private void LoadCreation()
        {
            SceneTransist(new CharacterCreateScene());
            //var scene = new CharacterCreateScene();
            //Core.Scene = scene;
        }

        private void LoadGameState()
        {
            SceneTransist(new TownScene());
            //Core.Scene = new TownScene();
        }

        private void LoadServerMenu(List<GameServerInfo> data)
        {
            SceneTransist(new ServerScene(data));
        }

        private void SceneTransist(Scene scene)
        {
            Core.StartSceneTransition(new WindTransition(() => scene));
        }

    }
}
