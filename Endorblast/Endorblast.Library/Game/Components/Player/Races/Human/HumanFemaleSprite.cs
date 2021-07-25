using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library.Game.Player.Races
{
    public class HumanFemaleSprite : BaseCharacterSprite
    {

        public HumanFemaleSprite() : base()
        {
           
        }

        protected override void LoadInfomation()
        {
            headOffset = new Vector2(0, -5);
            headSpriteOffset = new Vector2(12, 12);
        }
        
        protected override void LoadSprites()
        {
            base.LoadSprites();
            
            
            
            string basePath = "Content/Textures/Spritesheets/Player/Warrior/Human/Female/";
            

            int sizeW = 64;
            int sizeH = 64;

            HeadSprite = ContentLoader.LoadSprite(basePath + "Head.png");
            
            BaseSprites.Add(ActionType.Idle, new SpriteAnimation(basePath + "Human_Idle.png", sizeW, sizeH, 10));
            BaseSprites.Add(ActionType.Walking, new SpriteAnimation(basePath + "Human_Walking.png", sizeW, sizeH, 10));
            BaseSprites.Add(ActionType.Jump, new SpriteAnimation(basePath + "Human_Jump.png", sizeW, sizeH, 0));
        }
    }
}