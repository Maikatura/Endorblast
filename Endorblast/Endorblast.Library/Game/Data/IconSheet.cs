using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Data
{
    public class IconSheet
    {

        public string Name;
        
        private string FilePath = "";

        public Texture2D textureSheet;

        private int amountOfIcons = 0;

        public int IconAmount => amountOfIcons;

        public Dictionary<int, Rectangle> icon;

        private int iconSize = 16;
        
        public IconSheet(string name, string path, GraphicsDevice graphicsDevice)
        {
            Name = name;
            icon = new Dictionary<int, Rectangle>();

            using (Stream fileStream = File.OpenRead(path))
            {
                textureSheet = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            var x = textureSheet.Width / iconSize;
            var y = textureSheet.Height / iconSize;
            
            amountOfIcons = 0;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                
                    icon.Add(amountOfIcons, new Rectangle(i * iconSize, j * iconSize,iconSize,iconSize));
                    amountOfIcons++;
                }
            }

            
        }
        

    }
}