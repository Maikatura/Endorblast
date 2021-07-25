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

            new MapManager().InitGameMap(this, MapType.TownPrototype);
            //DiscordRpc.Instance.SetStatus($"EndorblastEngine Demo", "World: Town");
            
            
            //InventoryUI.NewInstanse(this);
            //GearUI.Instance.Init(this);
            SamplerState = SamplerState.PointClamp;
            Entity demoPlayer = new MainPlayer("DemoPlayer")
            {
                Gender = GenderTypes.Female,
                Race = PlayerRaceTypes.Dragon,
                PlayableClass = PlayerClassTypes.Warrior,
                Name = "Maikatura",
                Level = 10
            };
            
            
            this.AddEntity(demoPlayer);
            
        }
    }
}
