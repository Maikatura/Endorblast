using System;
using Nez.Sprites;

namespace Endorblast.Lib
{
    class BaldHair : HairObject
    {
        
        public BaldHair(int id, string name) : base(id, name)
        {
            hairName = name;
            
            frontHairIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            frontHairRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
           
            backHairIdle = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            backHairRunning = new SpriteAnimation(LoadSpriteAtlas($"{path}/nothing/nothing.png"), 10);
            
            Id = id;
            Console.WriteLine($"Loaded ID:{id}");
        }
        
    }
}