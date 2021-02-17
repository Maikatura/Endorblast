using Endorblast.Lib.Enums;

namespace Endorblast.Lib.Scenes
{
    class SnowlandsScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            GameSetup();

            SceneManager.InitGameMap(this, MapType.Snowlands);
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}