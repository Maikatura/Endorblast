using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Game.GameObjects.Enviorment
{
    class FirePole : Entity
    {

        public override void OnAddedToScene()
        {
            var sani = this.AddComponent(new SpriteAnimator());
            sani.LocalOffset = new Microsoft.Xna.Framework.Vector2(0, 0);
            sani.RenderLayer = 65;

            var sprites = ContentLoader.LoadSprites("/Effects/Fire/FirePole1.png", 100, 100);
            sprites = CenterSprite.BottomOrigin(sprites);

            
            var animation = new SpriteAnimation(sprites, 30);
           
            sani.AddAnimation("Fire", animation);
            sani.Play("Fire");



        }

    }
}
