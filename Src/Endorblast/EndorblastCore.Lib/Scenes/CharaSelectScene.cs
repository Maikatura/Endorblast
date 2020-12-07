using EndorblastCore.Lib.GUI;
using EndorblastCore.Lib.Network;
using Nez;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.Scenes
{
    class CharaSelectScene : BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();


            //DiscordRpc.Instance.SetDetails("Character Selection");

        }

        public CharaSelectScene(List<DatabaseCharacter> charaSelect)
        {

            CharacterSelectionUI.LoadCharacterUI(this, charaSelect);
            DiscordRpc.Instance.SetStatus("Character Selection", $"Characters: {charaSelect.Count}");
        }
    }
}
