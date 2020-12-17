using Endorblast.Lib.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endorblast.Lib.Scenes
{
    class CharacterCreateScene : BaseScene
    {


        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();


            DiscordRpc.Instance.SetDetails("Character Creation");
            CharacterCreationUI.Instance.Init(this);
        }

    }
}
