using System.Collections.Generic;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library.Player
{
    public class OutfitChanger : Component
    {

        public SpriteRenderer bodyPart;
        public List<Sprite> options = new List<Sprite>();

        private int currentOption = 0;

        public void ChangeHat()
        {
            
        }


    }
}