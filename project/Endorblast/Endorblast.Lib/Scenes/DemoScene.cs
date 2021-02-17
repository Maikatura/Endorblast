using Endorblast.Lib.Enums;
using Endorblast.Lib.GUI;
using Nez;
using Nez.Tiled;
using Endorblast.Lib.Discord;
using Endorblast.Lib.Entities;
using Endorblast.Lib.Game.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Scenes
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
            DiscordRpc.Instance.SetStatus($"Endorblast Demo", "World: Town");

            AddSceneComponent(new Zoom(Camera));
            InventoryUI.NewInstanse(this);
            GearUI.Instance.Init(this);
            SamplerState = SamplerState.PointClamp;

            Entity demoPlayer = new Entity("DemoPlayer");
            var collider = demoPlayer.AddComponent(new BoxCollider(16, 64));
            collider.IsTrigger = true;
            demoPlayer.AddComponent(new TiledMapMover(SceneManager.groundLayer));
            demoPlayer.AddComponent(new FollowCamera());
            demoPlayer.AddComponent(new MainPlayer());
            demoPlayer.AddComponent(new KeyboardInputComp());
            this.AddEntity(demoPlayer);
        }
    }
}
