using EndorblastCore.Lib.GUI;
using System;
using System.Collections.Generic;
using System.Text;
using Nez;
using Nez.Sprites;

namespace EndorblastCore.Lib.Scenes
{
    class SplashscreenScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
            
            var image = CreateEntity("SplashScreen");
            var sprite = image.AddComponent(new SpriteRenderer());
            sprite.SetSprite(ContentLoader.LoadSprite(("/Sprites/Logos/Splashscreen1.png")));
            sprite.SetRenderLayer(RenderLayers.FrontObjectLayer);

            float time = 4;

            
            
            
        }

        public override void OnStart()
        {
            base.OnStart();

            GameState.Instance.SetGameState(CurrentGameState.MainMenu);
            
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
}