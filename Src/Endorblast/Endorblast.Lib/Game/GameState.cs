using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Network;
using Endorblast.Lib.Enums;
using Endorblast.Lib.GUI;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez.DeferredLighting;
using Endorblast.Lib.Scenes;
using Nez.BitmapFonts;

namespace Endorblast.Lib
{

    public enum CurrentGameState
    {
        DemoScene,
        SplashScreen,
        MainMenu,           // Login screen
        RegisterMenu,       // Where you register youself
        CharacterSelection,
        CharacterCreation,
        PlayingState,       // Player is ingame an running the full game
    }

    public class GameState
    {
        public static GameState Instance { get; } = new GameState();

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
            LoadGameState(gameState, charaSelect);
        }


        private void LoadGameState(CurrentGameState gameStateToSet, List<DatabaseCharacter> charaSelect = null)
        {
            switch (gameStateToSet)
            {
                case CurrentGameState.DemoScene:
                    var scene = new DemoScene();
                    Core.Scene = scene;
                    break;
                case CurrentGameState.SplashScreen:
                    var scene2 = new SplashscreenScene();
                    Core.Scene = scene2;
                    break;
                case CurrentGameState.MainMenu:
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
                default:
                    break;
            }
        }



        private void LoadMainMenu()
        {
            var scene = new LoginScene();
            Core.Scene = scene;
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

        private void SceneTransist(Scene scene)
        {
            Core.StartSceneTransition(new WindTransition(() => scene));
        }

    }
}
