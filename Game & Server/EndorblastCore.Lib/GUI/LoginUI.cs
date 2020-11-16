using EndorblastCore.Lib.Network;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;

namespace EndorblastCore.Lib.GUI
{
    public class LoginUI
    {
        public static Stage stage;
        public static Table table;
        static Table insideBox;
        static UICanvas canvas;
        static TextField username;
        static TextField password;

        static TextButton button;

        public static void Init()
        {
            Entity UI = new Entity("LoginMenu");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(-1);

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
            username = new TextField("", style1);
            insideBox.Add(lbl2).Center().SetPadTop(20).Width(250);
            insideBox.Row();
            insideBox.Add(username).Width(250).Height(40).Center();

            insideBox.Row();

            Label lbl3 = new Label("Password:");
            lbl3.SetFontScale(2, 2);
            lbl3.SetAlignment(Align.Left);
            TextFieldStyle style2 = TextFieldStyle.Create(Color.White, Color.White, Color.White, Color.Black);
            password = new TextField("", style1);


            password.SetPasswordMode(true);
            insideBox.Add(lbl3).Center().SetPadTop(20).Width(250);
            insideBox.Row();
            insideBox.Add(password).Width(250).Height(40).Center();

            insideBox.Row();
            button = new TextButton("Login", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));

            button.OnClicked += button => InitJoin();

            button.GetLabel().SetFontScale(2, 2);
            insideBox.Add(button).Width(200).Height(30).SetPadTop(20);

            table.AddElement(insideBox);


            Core.Scene.AddEntity(UI);
        }


        public static void InitJoin()
        {
            LoginUserCommand.Send(username.GetText(), password.GetText());
        }

    }
}
