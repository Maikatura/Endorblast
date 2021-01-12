using Microsoft.Xna.Framework;
using Nez.Textures;

namespace Endorblast.Lib.Game.Player.Races
{
    class RaceClass
    {

        protected string path;
        
        
        // if someone of these are empty and call them program WILL crash.
        public Sprite[] idle;
        public Sprite[] walking;
        public Sprite[] basicAttack;
        
        // Customization // Does nothing right now.
        public Color hairColor;
        public Color skinColor;

        public RaceClass()
        {
            // Basic Settings!
            path = "/Sprites/Player/Races";
        }
        
        
    }
}