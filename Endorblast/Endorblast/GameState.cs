using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endorblast
{


    public enum CurrentGameState
    {
        MainMenu,           // Login screen
        RegisterMenu,       // Where you register youself
        CharacterSelection,
        CharacterCreation,
        PlayingState,       // Player is ingame an running the full game
    }


    class GameState
    {
        private static CurrentGameState gameState;
        public static Scene activeGameScene;
        
        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public static CurrentGameState GetGameState()
        {
            return gameState;
        }

        public static void SetGameState(CurrentGameState wantedGameState)
        {

            if (activeGameScene == null)
            {
                activeGameScene = Scene.CreateWithDefaultRenderer(Color.CornflowerBlue);
                Core.Scene = activeGameScene;
            }

            gameState = wantedGameState;
            LoadGameState(gameState);

        }


        private static void LoadGameState(CurrentGameState gameStateToSet, List<DatabaseCharacter> charaSelect = null)
        {
            switch (gameStateToSet)
            {
                case CurrentGameState.MainMenu:
                    LoadMainMenu();
                    break;
                case CurrentGameState.RegisterMenu:
                    Console.WriteLine("Not made!");
                    break;
                case CurrentGameState.CharacterSelection:
                    LoadCharacterSelect(charaSelect);
                    break;
                case CurrentGameState.PlayingState:
                    LoadGameState();
                    break;

                default:
                    break;
            }
        }



        private static void LoadMainMenu()
        {
            //NetworkConfig.ChangeServer(ClientSettings.loginPort);
            ReloadScene();

            


            

            SceneManager.LoadLoginBG();
            LoginUI.Init();
        }

        private static void LoadGameState()
        {
            //NetworkConfig.ChangeServer(ClientSettings.gamePort);
            ReloadScene();


            SceneManager.InitGameMap();

            GameManager.instance.AddEntity(1, true);
            //InventoryUI.InitInventory();
        }

        public static void LoadCharacterSelect(List<DatabaseCharacter> charaSelect)
        {
            //NetworkConfig.ChangeServer(ClientSettings.loginPort);
            ReloadScene();

            CharacterSelectionUI.LoadCharacterUI(charaSelect);
        }


        private static void ReloadScene()
        {
            for (int i = 0; i < Core.Scene.Entities.Count; i++)
            {
                if (Core.Scene.Entities[i] != null)
                {
                    if (!Core.Scene.Entities[i].HasComponent<Camera>())
                    {
                        Core.Scene.Entities[i].Destroy();
                    }
                }
            }
        }
    }
}
