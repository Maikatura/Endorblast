using Endorblast.Library.Enums;
using Endorblast.Library.Game.Player.Races;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library.Classes
{
    public class BaseWarriorClass : BaseCharacterClass
    {

        public BaseWarriorClass()
        {
            CharacterClassName = "Warrior";
            CharacterClassDescription = "I like sword. Me swing sword, Me hurt you with sword.";
            CharacterClassSecret = "I hate everything if this source code leaks I am going to be mad :)";
            
            Strength = 200;
            Intellect = 0;
            Mana = 0;
            Stamina = 100;
        }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            sprites = new HumanFemaleSprite();
        }
    }
}