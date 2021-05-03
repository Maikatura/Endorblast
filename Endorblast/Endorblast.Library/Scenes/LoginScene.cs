using System;
using System.Collections.Generic;
using System.Text;
using Endorblast.Library.Enums;
using Endorblast.Library.GUI;

namespace Endorblast.Library.Scenes
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

            SceneManager.InitGameMap(this, MapType.LoginMap);
            LoginUI.Init(this);
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}
