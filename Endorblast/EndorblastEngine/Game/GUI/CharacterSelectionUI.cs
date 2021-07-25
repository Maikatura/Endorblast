using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Game.Data;
using Endorblast.Library;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;
using Endorblast.Library.Network;
using EndorblastEngine.Network.NetworkCmd.Game;
using Nez.BitmapFonts;

namespace Endorblast.Library.GUI
{
    class CharacterSelectionUI
    {

        static UICanvas canvas;
        static Table charaSelectBar;
        static Table playTable;
        static Entity previewPlayer;

        static int currentSelectedChara = 0;

        static List<CharacterSelectionData> charsList = new List<CharacterSelectionData>();
        //static DatabaseCharacter selectedChara;


        public static void LoadCharacterUI(Scene scene, List<CharacterSelectionData> chars)
        {
            // Setup table right 
            Entity canvasEntity = new Entity("CharaSel-UI");
            canvas = canvasEntity.AddComponent(new UICanvas());
            canvas.SetRenderLayer((int)RenderLayers.Layer.UILayerMin);

            charaSelectBar = canvas.Stage.AddElement(new Table());
            playTable = canvas.Stage.AddElement(new Table());

            charaSelectBar.SetFillParent(true);
            playTable.SetFillParent(true);


            charsList = new List<CharacterSelectionData>();

            for (int i = 0; i < chars.Count; i++)
            {
                charsList.Add(chars[i]);
            }


            Stack playerLabel = new Stack();
            Label charaNameTest = new Label("Characters");
            Label charaNameTest2 = new Label($"{charsList.Count}/10");


            var classicButtonStyle = TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray);
            
            TextButton playButton = new TextButton($"Play", classicButtonStyle);

            
            charaNameTest.SetFontScale(2, 2);
            charaNameTest2.SetFontScale(2, 2);
            playButton.GetLabel().SetFontScale(2, 2);

            charaSelectBar.Top().Right();

            playerLabel.Add(charaNameTest).SetAlignment(Align.BottomLeft);
            playerLabel.Add(charaNameTest2).SetAlignment(Align.BottomRight);
            charaSelectBar.Add(playerLabel).Width(300).Height(40);
            charaSelectBar.Row();

            if (chars.Count != 0)
            {
                LoadCharaID(scene, 0);

                for (int i = 0; i < chars.Count; i++)
                {
                    var chara = chars[i];
                    
                    TextButton charaSelectButton = new TextButton($"Lv.{chara.Level} {chara.CharacterName}", classicButtonStyle);
                    charaSelectButton.GetLabel().SetAlignment(Align.Left);
                    charaSelectButton.GetLabel().SetOffset(50, 0);
                    charaSelectButton.GetLabel().SetFontScale(2, 2);
                    charaSelectButton.OnClicked += button => currentSelectedChara = chara.ID;
                    charaSelectBar.Add(charaSelectButton).Width(300).Height(40);
                    charaSelectBar.Row();
                }
            }

            TextButton selectButton = new TextButton($"+", classicButtonStyle);
            selectButton.GetLabel().SetFontScale(2, 2);
            charaSelectBar.Add(selectButton).Width(300).Height(40);
            charaSelectBar.Row();
            selectButton.OnClicked += button => LoadCharacterCreation();
            
            
            playTable.Right().Bottom();
            playTable.Add(playButton).Width(300).Height(50);

            playButton.OnClicked += button => JoinGame(currentSelectedChara);

            scene.AddEntity(canvasEntity);

        }
        
        
        private static void LoadCharaID(Scene scene, int id)
        {
            if (previewPlayer == null)
            {
                previewPlayer = new Entity();
                previewPlayer.AddComponent(new PreviewPlayer());
                scene.AddEntity(previewPlayer);

                previewPlayer.SetPosition(Screen.Center);
                previewPlayer.SetScale(new Vector2(4,4));
            }
            

        }

        private static void JoinGame(int charaID)
        {
            Console.WriteLine(charaID);
            new ClientEnterWorldCmd().Send(charaID);
        }

        private static void LoadCharacterCreation()
        {
            
        }

    }
}
