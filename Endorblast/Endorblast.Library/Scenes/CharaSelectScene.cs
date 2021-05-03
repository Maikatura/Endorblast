using System.Collections.Generic;
using Endorblast.Library.Discord;
using Endorblast.Library.GUI;
using Endorblast.Library.Network;

namespace Endorblast.Library.Scenes
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
