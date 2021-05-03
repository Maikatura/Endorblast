using Endorblast.Library.Discord;
using Endorblast.Library.Enums;
using Endorblast.Library.GUI;
using Endorblast.Library.Network;

namespace Endorblast.Library.Scenes
{
    class TownScene : BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            GameSetup();

            SceneManager.InitGameMap(this, MapType.Town);
            DiscordRpc.Instance.SetStatus($"Character: {NetworkManager.CharacterName}", "World: Town");

            NetworkManager.Instance.State = NetworkState.InGame;
            new WorldCharacterEnterCommand().Send();

            InventoryUI.NewInstanse(this);
            GearUI.Instance.Init(this);
        }


       
    }
}
