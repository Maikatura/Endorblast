using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;


namespace GamerEngineNet_Client
{
    class LoginUI
    {
        public static Stage stage;
        public static Table table;
        static Table insideBox;
        static UICanvas canvas;

        public static void Init()
        {
            Entity UI = new Entity("UI");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(-100);

            table = canvas.Stage.AddElement(new Table());
            insideBox = canvas.Stage.AddElement(new Table());

            table.SetFillParent(true);
            insideBox.SetFillParent(true);

            Sprite lgBg = new Sprite(Core.Content.LoadTexture("Content/UI/Login/UI_Login2.png"));
            Image img = new Image(lgBg);

            img.SetScaling(Scaling.StretchX);
            img.SetWidth(500);
            table.Add(img).Width(500).Height(400);




            Label lbl = new Label("Login");
            lbl.SetAlignment(Align.Center);
            lbl.SetFontScale(4, 4);
            lbl.SetWrap(true);
            insideBox.Add(lbl).SetExpandX();
            insideBox.Row();


            Label lbl2 = new Label("Username:");
            lbl2.SetFontScale(2, 2);
            lbl2.SetAlignment(Align.Left);
            TextFieldStyle style1 = TextFieldStyle.Create(Color.White, Color.White, Color.White, Color.Black);
            TextField txtFid = new TextField("", style1);
            insideBox.Add(lbl2).Center().SetPadTop(20).Width(250);
            insideBox.Row();
            insideBox.Add(txtFid).Width(250).Height(40).Center();

            insideBox.Row();

            Label lbl3 = new Label("Password:");
            lbl3.SetFontScale(2, 2);
            lbl3.SetAlignment(Align.Left);
            TextFieldStyle style2 = TextFieldStyle.Create(Color.White, Color.White, Color.White, Color.Black);
            TextField txtFid2 = new TextField("", style1);


            txtFid2.SetPasswordMode(true);
            insideBox.Add(lbl3).Center().SetPadTop(20).Width(250);
            insideBox.Row();
            insideBox.Add(txtFid2).Width(250).Height(40).Center();

            insideBox.Row();
            TextButton button = new TextButton("Login", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));

            button.GetLabel().SetFontScale(2, 2);
            insideBox.Add(button).Width(200).Height(30).SetPadTop(20);

            table.AddElement(insideBox);


            Core.Scene.AddEntity(UI);
        }


        public static void InitJoin()
        {
            
        }

    }
}
