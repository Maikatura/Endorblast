using Endorblast.Lib.GUI;
using Endorblast.Lib.Network;
using System.Collections.Generic;
using Endorblast.Lib.Discord;

namespace Endorblast.Lib.Scenes
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
