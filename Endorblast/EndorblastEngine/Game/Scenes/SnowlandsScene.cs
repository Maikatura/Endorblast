using Endorblast.Library.Enums;

namespace Endorblast.Library.Scenes
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

            //MapManager.InitGameMap(this, MapType.Snowlands);
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}