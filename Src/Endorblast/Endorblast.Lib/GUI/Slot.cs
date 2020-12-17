using Endorblast.GamePlay.Items;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Textures;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;

namespace Endorblast.Lib.GUI
{
    class Slot : Element
    {
        Sprite icon;
        //Sprite slotSprite;

        public Image slotIcon;
        public Stack slotItem;
        Image itemSprite;

        //Item item;


        void Init()
        {

            
        }

        public Slot()
        {
            slotIcon = new Image();
        }

        public Slot(Table table)
        {

            icon = InventoryContent.slotIcon;

            // Create everything for the slot
            slotIcon = new Image();
            itemSprite = new Image();
            slotItem = new Stack();

            // Add the images to the table
            slotItem.Add(slotIcon);
            slotItem.Add(itemSprite);

            // Add the slot to table
            table.Bottom().Add(slotItem).SetPadBottom(20).SetPadLeft(2).SetPadRight(2);
        }

        public void SetItemSprite(Sprite sprite)
        {
            
        }

    }
}
