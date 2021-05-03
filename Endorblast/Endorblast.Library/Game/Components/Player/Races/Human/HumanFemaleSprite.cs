using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Nez.Sprites;

namespace Endorblast.Library.Game.Player.Races
{
    public class HumanFemaleSprite : BaseCharacterSprite
    {

        public HumanFemaleSprite() : base()
        {
            
        }
        
        protected override void LoadSprites()
        {
            base.LoadSprites();
            
            string basePath = "Content/Textures/Spritesheets/Player/Warrior/Human/Female/";

            int sizeW = 64;
            int sizeH = 64;
            
            BaseSprites.Add(ActionType.Idle, new SpriteAnimation(basePath + "Human_Idle.png", sizeW, sizeH, 10));
            BaseSprites.Add(ActionType.Walking, new SpriteAnimation(basePath + "Human_Walking.png", sizeW, sizeH, 10));
            BaseSprites.Add(ActionType.Jump, new SpriteAnimation(basePath + "Human_Jump.png", sizeW, sizeH, 0));
        }
    }
}