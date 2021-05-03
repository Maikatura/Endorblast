using System.Net.Mime;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Data
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool Stackable { get; set; }
        
        public bool Equippable { get; set; }
        
        public bool Consumable { get; set; }

        public int IconId { get; set; } = 0;

        public int IconSheetId { get; set; } = 0;

        public int Value { get; set; } = 0;
    }
}