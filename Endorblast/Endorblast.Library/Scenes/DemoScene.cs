using Nez;
using Nez.Tiled;
using Endorblast.Library.Discord;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;
using Endorblast.Library.Game.Components;
using Endorblast.Library.GUI;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Library.Scenes
{
    class DemoScene : BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            GameSetup();
            
            
            //NetworkManager.Instance.State = NetworkState.InGame;
            SceneManager.InitGameMap(this, MapType.Town);
            DiscordRpc.Instance.SetStatus($"EndorblastEngine Demo", "World: Town");

            AddSceneComponent(new Zoom(Camera));
            InventoryUI.NewInstanse(this);
            GearUI.Instance.Init(this);
            SamplerState = SamplerState.PointClamp;

            Entity demoPlayer = new Entity("DemoPlayer");
            var collider = demoPlayer.AddComponent(new BoxCollider(16, 64));
            collider.IsTrigger = true;
            demoPlayer.AddComponent(new TiledMapMover(SceneManager.groundLayer));
            demoPlayer.AddComponent(new FollowCamera());
            demoPlayer.AddComponent(new BasePlayerV2());
            this.AddEntity(demoPlayer);
        }
    }
}
