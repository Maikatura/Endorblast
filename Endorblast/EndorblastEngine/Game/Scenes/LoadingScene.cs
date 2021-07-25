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
    class LoadingScene :  BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
            
            //new InfoBox().CreateInfoBox();
        }

        public override void OnStart()
        {
            base.OnStart();
            
            SamplerState = SamplerState.PointClamp;
            
        }
        
    }
}