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


            new MapManager().InitGameMap(this, MapType.Town);
            //DiscordRpc.Instance.SetStatus($"Endorblast Demo", "Character: Your mom");
            
            SamplerState = SamplerState.PointClamp;
            //InventoryUI.NewInstanse(this);
            //GearUI.Instance.Init(this);
        }

        public TownScene(int charaId) : base(charaId)
        {
        }

       
    }
}
