using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;
using Endorblast.Lib.Network;
using Nez.BitmapFonts;

namespace Endorblast.Lib.GUI
{
    class CharacterSelectionUI
    {

        static UICanvas canvas;
        static Table charaSelectBar;
        static Table playTable;
        static Entity dummyPlayer;

        static int currentSelectedChara = 0;

        static List<DatabaseCharacter> charsList = new List<DatabaseCharacter>();
        //static DatabaseCharacter selectedChara;


        public static void LoadCharacterUI(Scene scene, List<DatabaseCharacter> chars)
        {
            // Setup table right 
            Entity canvasEntity = new Entity("CharaSel-UI");
            canvas = canvasEntity.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);

            charaSelectBar = canvas.Stage.AddElement(new Table());
            playTable = canvas.Stage.AddElement(new Table());

            charaSelectBar.SetFillParent(true);
            playTable.SetFillParent(true);


            charsList = new List<DatabaseCharacter>();

            for (int i = 0; i < chars.Count; i++)
            {
                charsList.Add(chars[i]);
            }


            Stack playerLabel = new Stack();
            Label charaNameTest = new Label("Characters");
            Label charaNameTest2 = new Label($"{charsList.Count}/10");



            TextButton playButton = new TextButton($"Play", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));



            charaNameTest.SetFontScale(2, 2);
            charaNameTest2.SetFontScale(2, 2);
            playButton.GetLabel().SetFontScale(2, 2);

            charaSelectBar.Top().Right();

            playerLabel.Add(charaNameTest).SetAlignment(Align.BottomLeft);
            playerLabel.Add(charaNameTest2).SetAlignment(Align.BottomRight);
            charaSelectBar.Add(playerLabel).Width(300).Height(40);
            charaSelectBar.Row();

            if (chars.Count == 0)
            {
                TextButton selectButton = new TextButton($"+", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                selectButton.GetLabel().SetFontScale(2, 2);
                charaSelectBar.Add(selectButton).Width(300).Height(40);
                charaSelectBar.Row();
                selectButton.OnClicked += button => LoadCharacterCreation();
            }
            else
            {
                LoadCharaID(scene, 0);

                for (int i = 0; i < chars.Count; i++)
                {
                    TextButton selectButton = new TextButton($"{chars[i].Name}", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                    selectButton.GetLabel().SetFontScale(2, 2);
                    selectButton.OnClicked += button => LoadCharaID(scene, i - 1);
                    charaSelectBar.Add(selectButton).Width(300).Height(40);
                    charaSelectBar.Row();
                    
                }
            }

            playTable.Right().Bottom();
            playTable.Add(playButton).Width(300).Height(50);

            playButton.OnClicked += button => JoinGame(currentSelectedChara);

            scene.AddEntity(canvasEntity);

        }

        private static void LoadCharaID(Scene scene, int id)
        {
            var chara = charsList[id];

            if (dummyPlayer == null)
            {
                int offset = 140;
                dummyPlayer = new Entity("DummyCharaSelect");
                dummyPlayer.AddComponent(new PlayerAnimations());
                
                dummyPlayer.SetScale(new Vector2(6, 6));
                dummyPlayer.SetPosition(Screen.Width / 2 - offset, Screen.Height / 2);
                scene.AddEntity(dummyPlayer);
            }
            Console.WriteLine($"ID:{chara.Name}");
            dummyPlayer.GetComponent<PlayerAnimations>().LoadSet(chara.hairStyle);
            dummyPlayer.GetComponent<PlayerAnimations>().LoadHair(1);


        }

        private static void JoinGame(int charaID)
        {
            NetworkManager.CharacterName = charsList[charaID].Name;
            GameState.Instance.SetGameState(CurrentGameState.PlayingState);
        }

        private static void LoadCharacterCreation()
        {
            GameState.Instance.SetGameState(CurrentGameState.CharacterCreation);
        }

    }
}
