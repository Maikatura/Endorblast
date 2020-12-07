using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.GUI;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.Scenes
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

            //NetworkManager.Instance.State = NetworkState.InGame;
            SceneManager.InitGameMap(this, MapType.Town);
            DiscordRpc.Instance.SetStatus($"Endorblast Demo", "World: Town");

            InventoryUI.NewInstanse(this);
            GearUI.Instance.Init(this);


            Entity demoPlayer = new Entity("DemoPlayer");
            var collider = demoPlayer.AddComponent(new BoxCollider(16, 64));
            collider.IsTrigger = true;
            demoPlayer.AddComponent(new TiledMapMover(SceneManager.groundLayer));
            demoPlayer.AddComponent(new FollowCamera());
            this.Camera.SetZoom(0.5f);
            demoPlayer.AddComponent(new MainPlayer());
            demoPlayer.AddComponent(new KeyboardInput());
            this.AddEntity(demoPlayer);
        }
    }
}
