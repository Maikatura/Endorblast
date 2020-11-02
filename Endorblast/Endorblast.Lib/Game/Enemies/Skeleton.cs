using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Endorblast.Lib.Enums;

namespace Endorblast.Lib
{
    public class Skeleton : Enemy
    {

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();


            var coll = this.Entity.AddComponent(new BoxCollider(64, 64));
            coll.IsTrigger = true;
            var sprite = this.Entity.AddComponent(new SpriteRenderer(ContentLoader.LoadSprite("/Enemies/Testing/Enemy1.png")));
            sprite.RenderLayer = 75;

            var test1 = this.Entity.AddComponent(new SpriteAnimator());
            test1.AddAnimation("Fire", ContentLoader.LoadSprites("/Effects/Fire/Fire1.png", 96, 96), 30);
            test1.LocalOffset = new Microsoft.Xna.Framework.Vector2(0, -16);
            test1.Play("Fire");
            test1.RenderLayer = 70;
        }

        public Skeleton()
        {
            type = EnemyType.Skeleton;
            enemyHealth = 1000;
            maxHealth = enemyHealth;
            attackDamage = 1;
        }

        public void SetPosition(float x, float y)
        {
            this.Transform.Position = new Vector2(x, y);
        }

    }
}
