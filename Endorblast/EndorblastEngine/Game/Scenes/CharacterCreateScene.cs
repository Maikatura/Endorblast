using Endorblast.Library.Discord;
using Endorblast.Library.GUI;

namespace Endorblast.Library.Scenes
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
