using Endorblast.Library.Game.Player.Races;
using Nez;

namespace Endorblast.Library.Game.Components.Player.Classes
{
    public class BaseMageClass : BaseCharacterClass
    {
        
        public BaseMageClass(Entity entity) : base(entity)
        {
            CharacterClassName = "Mage";
            CharacterClassDescription = "I read between all line and cast what I learn.";
            CharacterClassSecret = "Mage is so bad I dont wanna have it in this game.";
            
            Strength = 130;
            Intellect = 75;
            Mana = 100;
            Stamina = 0;
            
            sprites = new HumanFemaleSprite();

            Init();
        }
        
        public override void Update()
        {
            base.Update();
        }
        
    }
}