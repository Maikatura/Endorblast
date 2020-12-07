using EndorblastCore.Lib.Enums;

namespace EndorblastCore.Lib.Scenes
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

            SceneManager.InitGameMap(this, MapType.Snowlands);
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}