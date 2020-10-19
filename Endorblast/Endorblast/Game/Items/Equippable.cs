using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.GamePlay.Items
{

    public enum EquipType
    {
        Helmet,
        Clothes,
        Boots,
    }

    public class Equippable : Item
    {
        public int requieredLevel;


        public Item Copy()
        {
            Item item = new Equippable();
            item.name = name;
            item.description = description;
            item.itemID = itemID;
            item.itemType = itemType;
            item.maxStack = maxStack;
            item.GetItem<Equippable>().requieredLevel = requieredLevel;
            return item;
        }

        public T GetItem<T>() where T : Equippable => this as T;

    }
}
