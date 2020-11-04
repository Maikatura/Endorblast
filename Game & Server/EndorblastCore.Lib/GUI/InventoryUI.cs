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

        public static void NewInstanse() { instance = new InventoryUI(); }

        public static InventoryUI Instance => instance;

        Entity inventoryUIEntity;

        UICanvas canvas;
        Table hotbarIcons;
        Table inventory;
        Sprite slotIcon;

        int slotsAmount = 9;
        int invSlots = 15;

        bool openAndClosed = false;

        public Dictionary<int, Slot> slots = new Dictionary<int, Slot>();


        public InventoryUI()
        {
            InitInventory();
        }

        public void InitInventory()
        {
            slotIcon = new Sprite(Core.Content.LoadTexture("Content/UI/Login/UI_Login2.png"));
            Sprite silverSprite = new Sprite(Core.Content.LoadTexture("Content/Icons/Currency/Currency.png"));
            Sprite premiumSprite = new Sprite(Core.Content.LoadTexture("Content/Icons/Currency/CurrencyPremium.png"));

            Entity UI = new Entity("Inventory");
            canvas = UI.AddComponent(new UICanvas());
            canvas.SetRenderLayer(-1);
            canvas.Stage.SetDebugAll(true);

            // Hotbar
            hotbarIcons = canvas.Stage.AddElement(new Table());
            hotbarIcons.SetFillParent(true);

            for (int i = 0; i < slotsAmount; i++)
            {
                Slot newSlot = new Slot(hotbarIcons);

                if (i == 3)
                {
                    newSlot.SetItemSprite(silverSprite);
                }

                slots.Add(i, newSlot);
            }


            // Inventory
            inventory = canvas.Stage.AddElement(new Table());
            inventory.SetFillParent(true);
            inventory.Right();
            Image panel = new Image(slotIcon);


            Stack stack = new Stack();
            inventory.Add(stack).Height(525).Width(300).SetPadRight(20);
            stack.Add(panel);


            Table icons = new Table();

            //int y = 0;
            for (int i = 1; i < invSlots + 1; i++)
            {
                icons.Add(new Image(slotIcon));

                if (i % 3 == 0)
                {
                    icons.Row();

                }
            }

            Label silver = new Label("Silver Here");
            Label premium = new Label("Premium Here");
            silver.SetFontScale(2, 2);
            premium.SetFontScale(2, 2);
            Image silverIcon = new Image(silverSprite);
            Image premiumIcon = new Image(premiumSprite);

            icons.Add(silverIcon).SetColspan(1).Left().Width(32).Height(32).SetAlign(Align.Center);
            icons.Add(silver).SetUniformX().SetPadTop(10).SetColspan(3).Left().SetAlign(Align.Center);
            icons.Row();
            icons.Add(premiumIcon).SetColspan(1).Left().Width(32).Height(32).SetAlign(Align.Center);
            icons.Add(premium).SetPadTop(10).SetColspan(2).Left();

            stack.AddElement(icons);




            inventoryUIEntity = UI;
            inventoryUIEntity.SetEnabled(openAndClosed);
            Core.Scene.AddEntity(UI);
        }


        public void OpenAndCloseInv()
        {
            openAndClosed = !openAndClosed;
            inventoryUIEntity.SetEnabled(openAndClosed);
        }


    }
}
