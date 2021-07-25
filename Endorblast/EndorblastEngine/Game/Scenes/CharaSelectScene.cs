using System.Collections.Generic;
using Endorblast.Lib.Game.Data;
using Endorblast.Library.Discord;
using Endorblast.Library.GUI;
using Endorblast.Library.Network;

namespace Endorblast.Library.Scenes
{
    class CharaSelectScene : BaseScene
    {
        private List<CharacterSelectionData> charaList;
        
        public override void Initialize()
        {
            base.Initialize();
            
        }

        public override void OnStart()
        {
            base.OnStart();


            //DiscordRpc.Instance.SetDetails("Character Selection");

        }

        public void LoadCharacters(List<CharacterSelectionData> charaSelect)
        {
            
        }
        
        public CharaSelectScene(List<CharacterSelectionData> charaSelect)
        {
            CharacterSelectionUI.LoadCharacterUI(this, charaSelect);
            //DiscordRpc.Instance.SetStatus("Character Selection", $"Characters: {charaSelect.Count}");
        }
    }
}
