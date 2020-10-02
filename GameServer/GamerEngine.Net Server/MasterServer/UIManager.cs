using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;


namespace MasterServer
{
    class UIManager
    {

        public static Stage stage;
        public static Table table;
        static UICanvas canvas;
        static Label lbl;

        public static void Init()
        {


            Entity UI = new Entity("UI");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(-100);


            table = canvas.Stage.AddElement(new Table());
            table.SetFillParent(true);
            table.Top().Left();

            Core.Scene.AddEntity(UI);

            AddButton("Players: " + GameManager.playerList.Count);
        }


        public static void AddButton(string text)
        {
            lbl = new Label(text);
            lbl.SetFontScale(4, 4);

            lbl.SetAlignment(Align.TopLeft);


            table.Add(lbl);

        }

        public static void UpdateLabel()
        {
            lbl.SetText("Players: " + GameManager.playerList.Count);
        }

    }
}
