using Microsoft.Xna.Framework;
using Nez;
using Nez.DeferredLighting;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib.GameObjects
{
    class FirePole : Entity
    {

        public override void OnAddedToScene()
        {
            var areaLight = this.AddComponent(new PointLight(Color.Yellow));
            areaLight.SetRenderLayer(RenderLayers.LightLayer);
            areaLight.SetRadius(100f);
            

            var sani = this.AddComponent(new SpriteAnimator());
            sani.LocalOffset = new Microsoft.Xna.Framework.Vector2(0, 0);
            sani.RenderLayer = RenderLayers.OtherPlayersLayer;

            var sprites = ContentLoader.LoadSprites($"{ContentPath.Instance.goPath}/Fire/Fire1.png", 100, 100);
            sprites = CenterSprite.BottomOrigin(sprites);

            
            
            var animation = new SpriteAnimation(sprites, 30);
           
            sani.AddAnimation("Fire", animation);
            sani.Play("Fire");



        }

    }
}
