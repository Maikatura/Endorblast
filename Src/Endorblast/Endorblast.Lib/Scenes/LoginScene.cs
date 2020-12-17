using Endorblast.Lib.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endorblast.Lib.Scenes
{
    class LoginScene : BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();

            SceneManager.LoadLoginBG(this);
            LoginUI.Init(this);
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}
