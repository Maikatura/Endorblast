using Endorblast.Lib.Enums;
using Endorblast.Lib.GUI;
using Endorblast.Lib.Network;
using Endorblast.Lib.Discord;

namespace Endorblast.Lib.Scenes
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
