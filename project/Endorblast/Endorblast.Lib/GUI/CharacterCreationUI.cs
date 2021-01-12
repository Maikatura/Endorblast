using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endorblast.Lib.GUI
{
    class CharacterCreationUI
    {

        public static CharacterCreationUI Instance { get; } = new CharacterCreationUI();


        public Stage stage;
        public Table table;
        Table insideBox;
        UICanvas canvas;
        TextField username;
        TextField password;

        Entity dummyPlayer;

        private Label ItemName;

        public void Init(Scene scene)
        {

           

            Entity UI = scene.CreateEntity("CharacterCreation");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);

            table = canvas.Stage.AddElement(new Table());
            table.SetFillParent(true);

            Sprite leftButton = ContentLoader.LoadSprite("/Sprites/UI/Creation/ArrowButtonLeft.png");
            Sprite rightButton = ContentLoader.LoadSprite("/Sprites/UI/Creation/ArrowButtonRight.png");


            table.Right();
            //ImageButton


                
                int bottomPadding = 10;

                ItemName = new Label($"Name: 0");
                TextButton backButton = new TextButton($"Back", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                TextButton NextButton = new TextButton($"Next", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));

                ItemName.SetFontScale(3f);
                ItemName.SetAlignment(Align.Center);
                
                backButton.OnClicked += backButtonPress => PrevHair();
                NextButton.OnClicked += nextButtonPress => NextHair();
                
                table.Add(backButton).Center().Width(48).Height(48).SetPadBottom(bottomPadding);
                table.Add(ItemName).Width(300).Height(48).Center().SetPadBottom(bottomPadding);
                table.Add(NextButton).Center().Width(48).Height(48).SetPadBottom(bottomPadding).SetPadRight(40);
                table.Row();


                if (dummyPlayer == null)
            {
                int offset = 140;
                dummyPlayer = new Entity("DummyCharaCreate");
                dummyPlayer.AddComponent(new PlayerAnimationsComp());

                dummyPlayer.SetScale(new Vector2(6, 6));
                dummyPlayer.SetPosition(Screen.Width / 2 - offset, Screen.Height / 2);
                scene.AddEntity(dummyPlayer);
            }
            
            dummyPlayer.GetComponent<PlayerAnimationsComp>().LoadSet(1);
            dummyPlayer.GetComponent<PlayerAnimationsComp>().LoadHair(0);
            ItemName.SetText(HairID.GetHairName(1));

        }

        private void PrevHair()
        {
            var anim = dummyPlayer.GetComponent<PlayerAnimationsComp>();


                if (HairID.hairID.ContainsKey(anim.hairID - 1) && anim.hairID - 1 < 0)
                {
                    anim.LoadHair(anim.hairID - 1);
                    ItemName.SetText(HairID.GetHairName(anim.hairID - 1));
                }
                else
                {
                    anim.LoadHair(HairID.hairID.Count - 1);
                    ItemName.SetText(HairID.GetHairName(HairID.hairID.Count - 1));
                }
        }

        private void NextHair()
        {
            var anim = dummyPlayer.GetComponent<PlayerAnimationsComp>();

            
       
                if (HairID.hairID.ContainsKey(anim.hairID + 1) && anim.hairID + 1 < HairID.hairID.Count - 1)
                {
                    anim.LoadHair(anim.hairID + 1);
                    ItemName.SetText(HairID.GetHairName(anim.hairID + 1));
                }
                else
                {
                    anim.LoadHair(0);
                    ItemName.SetText(HairID.GetHairName(0));
                }
        }

    }
}
