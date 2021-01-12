using Microsoft.Xna.Framework;
using Nez;
using Nez.DeferredLighting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endorblast.Lib.Scenes
{
    class BaseScene : Scene
    {

        
        protected RenderLayerRenderer defaultRenderer;
        protected RenderLayerRenderer uiRenderer;
        
        public override void Initialize()
        {
            base.Initialize();
            
            SetDesignResolution(1280, 720, SceneResolutionPolicy.ShowAllPixelPerfect);

            
            // lightingRenderer = AddRenderer(new DeferredLightingRenderer(
            //     0, 
            //     RenderLayers.LightLayer,
            //     RenderLayers.FrontObjectLayer,
            //     RenderLayers.MainPlayerLayer, 
            //     RenderLayers.OtherPlayersLayer, 
            //     RenderLayers.ObjectLayer,
            //     RenderLayers.BackgroundLayer
            // ));
            // lightingRenderer.EnableDebugBufferRender = false;
            // lightingRenderer.SetAmbientColor(Color.White);
            
            var defaultRenderer = AddRenderer(new RenderLayerRenderer(
                0,
                RenderLayers.LightLayer,
                RenderLayers.FrontObjectLayer,
                RenderLayers.MainPlayerLayer, 
                RenderLayers.OtherPlayersLayer, 
                RenderLayers.ObjectLayer,
                RenderLayers.BackgroundLayer
                
                ));

            var uiRenderer = AddRenderer(new RenderLayerRenderer(
                1,
                RenderLayers.UILayer1,
                RenderLayers.UILayer2
                ));

            
        }


    }
}
