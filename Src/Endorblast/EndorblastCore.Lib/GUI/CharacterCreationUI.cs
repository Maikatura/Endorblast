using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.GUI
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

        public void Init(Scene scene)
        {

           

            Entity UI = scene.CreateEntity("CharacterCreation");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);

            table = canvas.Stage.AddElement(new Table());
            table.SetFillParent(true);

            Sprite leftButton = ContentLoader.LoadSprite("/UI/Creation/ArrowButtonLeft.png");
            Sprite rightButton = ContentLoader.LoadSprite("/UI/Creation/ArrowButtonRight.png");


            table.Right();
            //ImageButton

            for (int i = 0; i < 5; i++)
            {
                Image imgLeft = new Image(leftButton);
                Image imgRight = new Image(rightButton);

                Label ItemName = new Label($"Name: {i}");
                ItemName.SetFontScale(3f);
                ItemName.SetAlignment(Align.Center);

                int bottomPadding = 10;
                
                table.Add(imgRight).Center().Width(48).Height(48).SetPadBottom(bottomPadding);
                table.Add(ItemName).Width(200).Height(48).Center().SetPadBottom(bottomPadding);
                table.Add(imgLeft).Center().Width(48).Height(48).SetPadBottom(bottomPadding).SetPadRight(40);
                table.Row();
            }


            if (dummyPlayer == null)
            {
                int offset = 140;
                dummyPlayer = new Entity("DummyCharaCreate");
                dummyPlayer.AddComponent(new PlayerAnimations());

                dummyPlayer.SetScale(new Vector2(6, 6));
                dummyPlayer.SetPosition(Screen.Width / 2 - offset, Screen.Height / 2);
                scene.AddEntity(dummyPlayer);
            }
            
            dummyPlayer.GetComponent<PlayerAnimations>().LoadSet(1);
            dummyPlayer.GetComponent<PlayerAnimations>().LoadHair(1);




        }

    }
}
