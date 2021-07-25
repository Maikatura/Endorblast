using Endorblast.Library.Classes;
using Nez;

namespace Endorblast.Library.Entities.Player
{
    public class BasePlayerEntity : Entity, IUpdatable
    {
        
        protected BaseCharacterClass playerClass;
        protected Collider boxCollider;
        
        FollowCamera camera;

        public string CharacterName = "";
        public int WorldID = 1;

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            
            
            
        }
        
    }
}