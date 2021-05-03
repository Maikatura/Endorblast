using Endorblast.Library.Enums;
using Endorblast.Library.Game.Player.Races;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library.Classes
{
    public class BaseWarriorClass : BaseCharacterClass
    {

        public BaseWarriorClass(Entity entity) : base(entity)
        {
            CharacterClassName = "Warrior";
            CharacterClassDescription = "I like sword. Me swing sword, Me hurt you with sword.";
            CharacterClassSecret = "I hate everything if this source code leaks I am going to be mad :)";
            
            Strength = 200;
            Intellect = 0;
            Mana = 0;
            Stamina = 100;
            
            sprites = new HumanFemaleSprite();

            Init();
        }
        
        
        public override void Update()
        {
            base.Update();
            
            // Do update logic here.
            
        }
    }
}