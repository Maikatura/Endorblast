using System.Collections.Generic;
using Endorblast.LoginServer.Data;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class ServerSelectionUI
    {
        
        private static ServerSelectionUI instance = new ServerSelectionUI();
        public static ServerSelectionUI Instance => instance;
        
        
        public Stage stage;
        public Table table;
        Table insideBox;
        UICanvas canvas;

        public void LoadUI(List<GameServerInfo> data)
        {
            
            
            Entity UI = Core.Scene.CreateEntity("LoginMenu");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);

            table = canvas.Stage.AddElement(new Table());
            insideBox = canvas.Stage.AddElement(new Table());

            table.SetFillParent(true);
            insideBox.SetFillParent(true);

            Sprite lgBg = ContentLoader.LoadSprite(ContentPath.Instance.ui_Panel);
            
            Image img = new Image(lgBg);
            

            

            img.SetScaling(Scaling.Fill);
            table.Add(img).Width(300).Height(300);


            Label lbl = new Label("Login");
            lbl.SetAlignment(Align.Center);
            lbl.SetFontScale(4, 4);
            lbl.SetWrap(true);
            insideBox.Add(lbl).SetExpandX();
            insideBox.Row();

            foreach (var server in data)
            {
                var button = new TextButton(server.serverName, TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                button.OnClicked += button => JoinServer(server.ipAddress);

                button.GetLabel().SetFontScale(2, 2);
                insideBox.Add(button).Width(200).Height(30).SetPadTop(20);
            }

            table.AddElement(insideBox);
            
            
            
            
        }

        private void JoinServer(string ipAddress)
        {
            
        }
    }
}