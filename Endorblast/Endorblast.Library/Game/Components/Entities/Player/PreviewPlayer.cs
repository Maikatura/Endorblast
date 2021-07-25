using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Endorblast.Library.Game.Components.Player;
using Endorblast.Library.Movement;
using Endorblast.Library.Player;
using Nez;

namespace Endorblast.Library.Entities
{
    public class PreviewPlayer : Component, IUpdatable
    {
        
        private BaseCharacterClass playerClass;
        protected BaseMovement movement;
        
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            playerClass = Entity.AddComponent(new BaseWarriorClass());
            movement = Entity.AddComponent(new BaseMovement(false));
            Entity.AddComponent(new UpdateSelectPosition());

            LoadClass(GenderTypes.Female, PlayerRaceTypes.Human, PlayerClassTypes.Warrior);
        }

        public void LoadClass(GenderTypes gender, PlayerRaceTypes race, PlayerClassTypes type)
        {
            playerClass.LoadSprites(gender, race);
            movement = movement.GetMovement(type);
            
        }

        public void Update()
        {
            
        }
    }
}