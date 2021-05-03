using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Endorblast.Library.Scenes
{
    class SplashscreenScene : BaseScene
    {
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();

            var image = CreateEntity("SplashScreen");
            var sprite = image.AddComponent(new SpriteRenderer());
            image.SetPosition(Screen.Width / 2, Screen.Height / 2);
            sprite.SetSprite(ContentLoader.LoadSprite("/Textures/Misc/Logos/Splashscreen1.png"));
            sprite.SetRenderLayer(RenderLayers.FrontObjectLayer);
            
            AddSceneComponent(new Splashscreen());

            ClearColor = Color.Black;
        }

        public override void Unload()
        {
            base.Unload();

            this.Entities.RemoveAllEntities();
        }
    }
    
    public class Splashscreen : SceneComponent
    {
        private float delay = 3f;
        private bool isTriggered = false;
        
        public override void Update()
        {
            if (delay <= 0 && !isTriggered)
            {
                isTriggered = true;
                StateManager.Instance.SetGameState(CurrentGameState.LoginMenu);
            }
            
            delay -= Time.DeltaTime;
        }
    }
}