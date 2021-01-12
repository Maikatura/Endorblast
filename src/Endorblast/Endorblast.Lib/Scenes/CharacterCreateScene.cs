using Endorblast.Lib.GUI;
using Endorblast.Lib.Discord;

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
