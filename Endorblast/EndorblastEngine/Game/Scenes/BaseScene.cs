using Microsoft.Xna.Framework;
using Nez;
using Nez.DeferredLighting;
using System;
using System.Collections.Generic;
using System.Text;
using Endorblast.Library.Game.Components;

namespace Endorblast.Library.Scenes
{
    class BaseScene : Scene
    {

        int characterId;
        
        protected RenderLayerRenderer defaultRenderer;
        protected RenderLayerRenderer uiRenderer;
        
        public override void Initialize()
        {
            base.Initialize();
            
            SetDesignResolution(1920, 1080, SceneResolutionPolicy.None);


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
            
            defaultRenderer = AddRenderer(new RenderLayerRenderer(
                0,
                (int)RenderLayers.Layer.LightLayer,
                (int)RenderLayers.Layer.FrontObjectLayer,
                (int)RenderLayers.Layer.MainPlayer, 
                (int)RenderLayers.Layer.OtherPlayerMin, 
                (int)RenderLayers.Layer.OtherPlayerMax, 
                (int)RenderLayers.Layer.ObjectLayer,
                (int)RenderLayers.Layer.BackgroundLayer
                
                ));

            uiRenderer = AddRenderer(new RenderLayerRenderer(
                1,
                (int)RenderLayers.Layer.UILayerMin,
                (int)RenderLayers.Layer.UILayerMax
                ));

            
        }

        public virtual void GameSetup()
        {
            // Setup Logic for Scene here: Like Camera Effects and Post Process effects.
            AddSceneComponent(new Zoom(Camera));
            
            if (characterId == GameManager.GetCharacterID)
            {
                GameManager.Instance.AddPlayer("Maika", true);
            }
        }


        public BaseScene()
        {
            
        }

        public BaseScene(int charaID)
        {
            characterId = charaID;
            
        }

    }
}
