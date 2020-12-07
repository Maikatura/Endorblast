using Microsoft.Xna.Framework;
using Nez;
using Nez.DeferredLighting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.Scenes
{
    class BaseScene : Scene
    {

        public override void Initialize()
        {
            base.Initialize();


            SetDesignResolution(1280, 720, SceneResolutionPolicy.ShowAllPixelPerfect);

            var deferred = AddRenderer(new DeferredLightingRenderer(
                0, 
                RenderLayers.LightLayer,
                RenderLayers.FrontObjectLayer,
                RenderLayers.MainPlayerLayer, 
                RenderLayers.OtherPlayersLayer, 
                RenderLayers.ObjectLayer,
                RenderLayers.BackgroundLayer
            ));
            deferred.EnableDebugBufferRender = false;
            deferred.SetAmbientColor(Color.LightGray);
            

            var defaultRenderer = AddRenderer(new RenderLayerRenderer(1, RenderLayers.UILayer1));
        }


    }
}
