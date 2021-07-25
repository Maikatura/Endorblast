using System.Collections.Generic;
using Endorblast.LoginServer.Data;
using EndorblastEngine.Network.NetworkCmd.Master;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class ServerSelectionUI
    {
        
        
        
        
        public Stage stage;
        public Table table;
        Table insideBox;
        UICanvas canvas;

        public void LoadUI(Scene scene, List<ServerInfo> data)
        {
            
            
            Entity UI = scene.CreateEntity("ServerSelectMenus");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer((int)RenderLayers.Layer.UILayerMin);

            table = canvas.Stage.AddElement(new Table());
            insideBox = canvas.Stage.AddElement(new Table());

            table.SetFillParent(true);
            insideBox.SetFillParent(true);

            //Sprite lgBg = ContentLoader.LoadSprite(ContentPath.Instance.ui_Panel);
            
            //Image img = new Image(lgBg);
            

            

            //img.SetScaling(Scaling.Fill);
            //table.Add(img).Width(300).Height(300);


            Label lbl = new Label("Server Selection");
            lbl.SetAlignment(Align.Center);
            lbl.SetFontScale(4, 4);
            lbl.SetWrap(true);
            insideBox.Add(lbl).SetExpandX();
            insideBox.Row();

            foreach (var server in data)
            {
                var button = new TextButton(server.ServerIdentity.ToString(), TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                button.OnClicked += button => JoinServer(server.ServerIdentity);

                button.GetLabel().SetFontScale(2, 2);
                insideBox.Add(button).Width(400).Height(50).SetPadTop(20);
            }

            table.AddElement(insideBox);

            


        }

        private void JoinServer(long serverIdentity)
        {
            new JoinGameServerCmd().Send(serverIdentity);
        }
    }
}