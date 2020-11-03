using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.GamePlay.Items
{

    


    public enum ItemType
    {
        Skill,
        Item,
        Usable,
        Equippable
    }

    public class Item
    {

        public string name;
        public string description;
        public int itemID;
        public ItemType itemType;
        public int maxStack;

        public Sprite icon;


        public T GetItem<T>() where T : Item => this as T;

    }
}
