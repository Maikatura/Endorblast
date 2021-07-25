using Endorblast.Library.GUI.ErrorMessageTypes;
using Endorblast.Library.Network;
using EndorblastEngine.Network.NetworkCmd;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class LoginUI : BaseUI
    {
        
        static TextField username;
        static TextField password;

        TextButton loginButton;


        private Sprite loginTabSprite;
        private Sprite lgBg;
        private Sprite tabInactiveSprite;
        private Sprite tabSprite;
        
        // UI Settings
        private Color UITextColor;

        public void Init(Scene scene)
        {
            // UI Settings
            UITextColor = Color.White;
            
            
            // Load Sprites
            tabSprite = ContentLoader.LoadSprite("Content/Textures/Spritesheets/UI/Tabs/Tab-Active.png");
            tabInactiveSprite = ContentLoader.LoadSprite("Content/Textures/Spritesheets/UI/Tabs/Tab-Inactive.png");
            lgBg = ContentLoader.LoadSprite("Content/Textures/Spritesheets/UI/Tabs/TabPanel-Register.png");
            loginTabSprite = ContentLoader.LoadSprite("Content/Textures/Spritesheets/UI/Tabs/TabPanel-Login.png");
            

            // UI Setup
            Entity UI = scene.CreateEntity("LoginMenu");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer((int)RenderLayers.Layer.UILayerMin);
            table = canvas.Stage.AddElement(new Table());
            
            table.SetFillParent(true);


            // Setup UI Styles
            TextFieldStyle inputFieldStyle1 = TextFieldStyle.Create(Color.White, Color.White, Color.White, Color.Black);
            TextButtonStyle textButtonStyle1 = TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray);
            TextButtonStyle registerButton = TextButtonStyle.Create(Color.Black, Color.White, Color.Gray);
            TabWindowStyle tabWindowStyle = new TabWindowStyle();
            TabButtonStyle tabStyle1 = new TabButtonStyle();
            TabStyle tabStyle2 = new TabStyle();
            TabStyle tabStyle3 = new TabStyle();
            
            
            // Setup UI Components
            Image img = new Image(lgBg);
            SpriteDrawable tabImage = new SpriteDrawable(tabSprite);
            SpriteDrawable tabInActiveImage = new SpriteDrawable(tabInactiveSprite);
            SpriteDrawable loginBGImage = new SpriteDrawable(loginTabSprite);
            SpriteDrawable regBGImage = new SpriteDrawable(lgBg);
            
            TextButton buttonRegister = new TextButton("Test", registerButton);
            username = new TextField("", inputFieldStyle1);
            password = new TextField("", inputFieldStyle1);
            loginButton = new TextButton("Login", textButtonStyle1);

            tabStyle1.Active = tabImage;
            tabStyle1.Inactive = tabInActiveImage;
            tabStyle1.Hover = tabImage;
            
            tabStyle1.LabelStyle = new LabelStyle();
            tabWindowStyle.TabButtonStyle = tabStyle1;
            tabStyle2.Background = loginBGImage;
            tabStyle3.Background = regBGImage;
            

            TabPane tabPane = new TabPane( tabWindowStyle);
            var loginTabPanel = new Tab("Login",tabStyle2);
            var registerTabPanel = new Tab("Register",tabStyle3);
            
            
            
            // Panel Image
            
            
            table.Add(tabPane);
            
            LoadLogin(loginTabPanel);
            LoadRegister(registerTabPanel);
            
            tabPane.AddTab(loginTabPanel);
            tabPane.AddTab(registerTabPanel);
            
        }


        private void LoadLogin(Tab tab)
        {
            Label lbl = new Label("Login");
            Label lbl2 = new Label("Username:");
            Label lbl3 = new Label("Password:");
            
            
            // Username label and input
            tab.Center();
            lbl2.SetFontScale(2, 2);
            lbl2.SetAlignment(Align.Left);
            lbl2.SetFontColor(UITextColor);
            tab.Add(lbl2).Center().SetPadTop(20).Width(250);
            tab.Row();
            tab.Add(username).Center().Width(250).Height(40).Center();
            tab.Row();

            
            // Password Label and input
            lbl3.SetFontScale(2, 2);
            lbl3.SetAlignment(Align.Left);
            lbl3.SetFontColor(UITextColor);
            password.SetPasswordMode(true);
            tab.Add(lbl3).Center().SetPadTop(20).Width(250);
            tab.Row();
            tab.Add(password).Width(250).Height(40).Center();
            tab.Row();

            
            // Join/Login Button
            loginButton.OnClicked += button => SendLoginRequest();
            loginButton.GetLabel().SetFontScale(2, 2);
            tab.Add(loginButton).Width(200).Height(30).SetPadTop(20);
            tab.Row();

            // Tabs Setup
        }

        private void LoadRegister(Tab tab)
        {
            
            Label usernameLabel = new Label("Username:");
            Label emailLabel = new Label("Email:");
            Label passwordLabel = new Label("Password:");
            TextButton registerButton = new TextButton("Register", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));

            usernameLabel.SetFontScale(2, 2);
            emailLabel.SetFontScale(2, 2);
            passwordLabel.SetFontScale(2, 2);
            usernameLabel.SetFontColor(UITextColor);
            emailLabel.SetFontColor(UITextColor);
            passwordLabel.SetFontColor(UITextColor);
            usernameLabel.SetAlignment(Align.Left);
            emailLabel.SetAlignment(Align.Left);
            passwordLabel.SetAlignment(Align.Left);

            registerButton.GetLabel().SetFontScale(2, 2);
            
            tab.Center();
            tab.Add(usernameLabel).Width(250).SetPadTop(20);
            tab.Row();
            tab.Add(emailLabel).Width(250).SetPadTop(20);
            tab.Row();
            tab.Add(passwordLabel).Width(250).SetPadTop(20);
            tab.Row();
            tab.Add(registerButton).Width(250).Height(40).SetPadTop(20).Center();
        }


        public static void SendLoginRequest()
        {
            new SendLoginCmd().Send(username.GetText(), password.GetText());
        }

    }
}
