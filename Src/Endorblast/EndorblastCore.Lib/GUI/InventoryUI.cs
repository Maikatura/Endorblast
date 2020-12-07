using Nez;
using Nez.Textures;
using Nez.UI;
using Nez.UI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EndorblastCore.Lib.GUI
{
    class InventoryUI
    {
        static InventoryUI instance;

        public static void NewInstanse(Scene scene) { instance = new InventoryUI(scene); }

        public static InventoryUI Instance => instance;

        Entity inventoryUIEntity;

        UICanvas canvas;
        Table hotbarIcons;
        Table inventory;
        Sprite slotIcon;

        Label premium;
        Label silver;

        int slotsAmount = 9;
        int invSlots = 20;

        bool openAndClosed = false;

        public Dictionary<int, Slot> slots = new Dictionary<int, Slot>();


        public InventoryUI(Scene scene)
        {
            InitInventory(scene);
        }

        public void InitInventory(Scene scene)
        {
            Sprite panelSprite = ContentLoader.LoadSprite(ContentPath.Instance.uiInventory);
            slotIcon = new Sprite(Core.Content.LoadTexture("Content/UI/Login/UI_Panel.png"));
            Sprite silverSprite = new Sprite(Core.Content.LoadTexture("Content/Icons/Currency/Currency.png"));
            Sprite premiumSprite = new Sprite(Core.Content.LoadTexture("Content/Icons/Currency/CurrencyPremium.png"));

            Entity UI = new Entity("Inventory");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);
            canvas.Stage.SetDebugAll(true);

            // Hotbar
            hotbarIcons = canvas.Stage.AddElement(new Table());
            hotbarIcons.SetFillParent(true);

            for (int i = 0; i < slotsAmount; i++)
            {
                Slot newSlot = new Slot(hotbarIcons);

                if (i == 4)
                {
                    newSlot.SetItemSprite(silverSprite);
                }

                slots.Add(i, newSlot);
            }


            // Inventory
            inventory = canvas.Stage.AddElement(new Table());
            inventory.SetFillParent(true);
            inventory.Right();
            Image panel = new Image(panelSprite);
            panel.SetScaling(Scaling.Fill);

            Stack stack = new Stack();
            
            inventory.Add(stack).Height(470).Width(300).SetPadRight(20);
            stack.Add(panel);



            Table icons = new Table();

            //int y = 0;
            for (int i = 1; i < invSlots + 1; i++)
            {
                icons.Add(new Image(slotIcon));

                if (i % 4 == 0)
                {
                    icons.Row();

                }
            }

            silver = new Label("Silver Here");
            silver.SetFontScale(2, 2);
            Image silverIcon = new Image(silverSprite);

            //premium = new Label("Premium Here");
            //premium.SetFontScale(2, 2);
            //Image premiumIcon = new Image(premiumSprite);

            icons.Add(silverIcon).SetColspan(1).SetPadTop(10).Left().Width(24).Height(24).SetAlign(Align.Center);
            icons.Add(silver).SetPadTop(10).SetColspan(3).Left();
            icons.Row();
            //icons.Add(premiumIcon).SetColspan(1).SetPadTop(10).Left().Width(24).Height(24).SetAlign(Align.Center);
            //icons.Add(premium).SetPadTop(10).SetColspan(2).Left();

            stack.AddElement(icons);




            inventoryUIEntity = UI;
            inventoryUIEntity.SetEnabled(openAndClosed);
            scene.AddEntity(UI);
        }


        public void OpenAndCloseInv()
        {
            openAndClosed = !openAndClosed;
            inventoryUIEntity.SetEnabled(openAndClosed);
        }


    }
}
