using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Endorblast.Library.Entities
{
    public class BasePlayerV2 : Component, IUpdatable
    {
        
        BaseCharacterClass playerClass;
        
        FollowCamera camera;
        
        
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            playerClass = new BaseWarriorClass(Entity);
            
            camera = this.GetComponent<FollowCamera>();
            camera.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);
            camera.Transform.Position = Entity.Transform.Position;
        }
        
        public void Update()
        {
            if (!Entity.Equals(null))
                playerClass.Update();
        }
    }
}