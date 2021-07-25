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

            new MapManager().InitGameMap(this, MapType.Town);
            new LoginUI().Init(this);
            
            
        }
        
    }
}
