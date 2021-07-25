using System;
using Endorblast.Library.Movement;
using Nez;

namespace Endorblast.Library
{
    public class MainPlayer : BasePlayer
    {
        private FollowCamera camera;
        
        public MainPlayer(string entityName) : base(entityName)
        {
            
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();

            AddComponent(new BaseInput(movement));
            
            camera = AddComponent(new FollowCamera(this , FollowCamera.CameraStyle.LockOn));
            camera.Transform.Position = Transform.Position;
        }
    }
}